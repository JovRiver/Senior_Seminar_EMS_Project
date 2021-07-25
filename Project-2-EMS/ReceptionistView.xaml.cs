using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using Project_2_EMS.Models.DatabaseModels;
using Project_2_EMS.Models.PatientModels;

namespace Project_2_EMS {
    public partial class ReceptionistView {
        // Create parent window to hold the MainWindow so that we can show it later
        private readonly Window _parentWindow;

        // Create a new appt window to hold the NewAppointmentWindow so that we can close it in
        // certain edge cases
        private Window newApptWindow;

        // Create global database sql handler and connection manager
        private readonly SqlDatabaseAccess db_Access = new SqlDatabaseAccess();

        // Create lists to hold appointments and patients for global use
        private List<PatientAppointment> Appointments = new List<PatientAppointment>();
        private List<PatientInfo> PatientList = new List<PatientInfo>();

        // Create global variables to hold the current week date and the previous week date
        // These are used when interacting with the calendar
        private DateTime weekDate;
        private DateTime prevWeekDate;

        public ReceptionistView(Window parentWindow, String staffMember) {
            InitializeComponent();

            // Initialize the labels at the top of the calendar and sign-in views
            InitializeHeadLabels();

            // Update the each of the views (information will change based on the date)
            UpdateReceptionistView();

            // Set the greeting based on who is signing in
            GreetingGrid.Content = "Greetings " + staffMember + "!";

            // Assign parent window and ready the onwindowclosing for when receptionistview is closed
            _parentWindow = parentWindow;
            //Closing += OnWindowClosing;
        }

        private void InitializeHeadLabels() {
            // Set the current weekdate based on the current date
            weekDate = DateTime.Now.AddDays(Convert.ToDouble(DateTime.Now.DayOfWeek.ToString("d")) * -1.0);
            
            // Set the selected date on the calendar to current date
            ApptCalendar.SelectedDate = DateTime.Now.Date;

            // Set the calendar view top label to show the week date in the given format
            AppointmentWeek.Content = weekDate.ToString("Week o\\f MMMM dd, yyyy");

            // Set the sign-in view top label to only show today's date
            SignInDate.Content = DateTime.Now.Date.ToLongDateString();
        }

        public void UpdateReceptionistView() {
            // Clear the appointment grid to prepare for new information
            ClearAppointmentGrid();

            // Populate the appointment grid with appointments for this week
            PopulateAppointmentGrid();

            // Populate the sign-in view with patients who have an appointment today
            PopulateSignInView();
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e) {
            // Close the new appt window if it exists
            if (newApptWindow != null) {
                newApptWindow.Close();
            }

            // Show the parent window after hiding the receptionist view window
            Hide();
            _parentWindow.Show();
        }

        private void OnWindowClosing(object sender, CancelEventArgs e) {
            // Close the new appt window if it exists
            if (newApptWindow != null) {
                newApptWindow.Close();
            }

            // Close the parent window when the receptionist view window is closed
            if (!_parentWindow.IsActive) {
                _parentWindow.Close();
            }
        }

        private void ControlButton_Click(object sender, RoutedEventArgs e) {
            // Cast the trigger source as a button
            Button btn = e.Source as Button;
            /** 
             *  I set the button names to be the same as the view names so that I could compare
             *  the names. If the button name equals the view name, then we make that view visible,
             *  else, we make the view invisible
             */ 
            foreach (Grid grid in ViewPanel.Children) {
                _ = grid.Name.Contains(btn.Name) ? grid.Visibility = Visibility.Visible : grid.Visibility = Visibility.Hidden;
            }

            // Hide the appointment button from the side panel and clear patient billing information
            ApptButtonGrid.Visibility = Visibility.Hidden;
            ClearPatientBilling();
        }

        private void ApptCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e) {
            if (ApptCalendar.SelectedDate.HasValue) {
                // Grab the date and the day number from the calendar
                var date = ApptCalendar.SelectedDate.Value;
                var dayNum = Convert.ToDouble(ApptCalendar.SelectedDate.Value.DayOfWeek.ToString("d"));

                // Set the weekdate and calendar view top label
                weekDate = date.AddDays(dayNum * -1.0);
                AppointmentWeek.Content = weekDate.ToString("Week o\\f MMMM dd, yyyy");

                // Highlight the day label on the calendar view to match the currently selected day
                HighlightCalendarDay(AppointmentDays, 0, (int)dayNum + 1);

                // If the weekdate changes, update the receptionist view information
                if (prevWeekDate != weekDate) {
                    prevWeekDate = weekDate;
                    UpdateReceptionistView();
                }
            }
        }

        // Code obtained from https://stackoverflow.com/questions/25352961/have-to-click-away-twice-from-calendar-in-wpf
        /**
         *  When clicking inside the calendar view, you would need to double click outside of it before being able
         *  to click on something outside of it. This code prevents that from happening
         */
        private void ApptCalendar_GotMouseCapture(object sender, MouseEventArgs e) {
            UIElement originalElement = e.OriginalSource as UIElement;
            if (originalElement is CalendarDayButton || originalElement is CalendarItem) {
                originalElement.ReleaseMouseCapture();
            }
        }

        private void GetPatientAppointments() {
            SelectAppointmentBy_DateRange <PatientAppointment> query = new SelectAppointmentBy_DateRange<PatientAppointment>(weekDate, weekDate.AddDays(6));
            Appointments = db_Access.ExecuteListQuery(query);
        }

        private void GetPatientById(int patId) {
            SelectPatientInfoBy_PatientId<PatientInfo> query = new SelectPatientInfoBy_PatientId<PatientInfo>(patId);
            PatientList.Add(db_Access.ExecuteListQuery(query)[0]);
        }

        private PatientInfo GetPatientByName() {
            string firstName = BillingFirstNameTb.Text;
            string lastName = BillingLastNameTb.Text;

            SelectPatientInfoBy_FullName_AND<PatientInfo> query = new SelectPatientInfoBy_FullName_AND<PatientInfo>(firstName, lastName);
            return db_Access.ExecuteListQuery(query)[0];
        }

        private void PopulateSignInView() {
            ClearSigninView();

            // Use a row index counter to drop to the next row after each addition to the sign-in view
            int rowIndex = 0;
            foreach (PatientAppointment appt in Appointments) {
                // Check if the current appointment is today
                if (appt.ApptDate == DateTime.Now.Date) {
                    foreach (PatientInfo patient in PatientList) {
                        // Check for each patient who's appointment is today by matching their Id's
                        if (appt.PatientId == patient.PatientId) {
                            // Grab each label with at the current row index from the sign-in view
                            Label visitId = GetChild(SignInVisitId, rowIndex, 0) as Label;
                            Label lastName = GetChild(SignInLastName, rowIndex, 0) as Label;
                            Label firstName = GetChild(SignInFirstName, rowIndex, 0) as Label;

                            // Set the sign-in information
                            visitId.Content = "[ " + appt.VisitId + " ]";
                            lastName.Content = patient.LastName;
                            firstName.Content = patient.FirstName;

                            // Increment the row index to be the next line in the sign-in view
                            rowIndex += 1;
                            break;
                        }
                    }
                }
            }
        }

        private void UpdateDbPatientBalance(int patientId, decimal cost) {
            UpdateBalanceBy_Cost_PatientId query = new UpdateBalanceBy_Cost_PatientId(cost, patientId);
            _ = db_Access.ExecuteNonQuery(query);
        }

        private void ClearSigninView() {
            // Loop through each child grid in the sing-in view and set their content to empty
            foreach (Label label in SignInVisitId.Children) { label.Content = String.Empty; }
            foreach (Label label in SignInLastName.Children) { label.Content = String.Empty; }
            foreach (Label label in SignInFirstName.Children) { label.Content = String.Empty; }
        }

        private void PopulateAppointmentGrid() {
            // Get all of the appointments for the current week
            // This populates the appointments list
            GetPatientAppointments();

            // Get all of the patients who have an appointment this week by their Id's
            // This populates the patients list
            foreach (PatientAppointment appt in Appointments) {
                GetPatientById(appt.PatientId);
            }

            foreach (PatientAppointment appt in Appointments) {
                // Initialize appt time and set a day variable to be the digit number of the day
                // (sunday = 0, monday = 1, etc...)
                string apptTime = String.Empty;
                double day = Convert.ToDouble(appt.ApptDate.DayOfWeek.ToString("d"));

                // Compare the current appointment time to a timespan time of 12:00:00 (PM)
                int diff = TimeSpan.Compare(appt.ApptTime, new TimeSpan(12,0,0));

                // Set the apptTime to a 12 hour system and set it as either AM or PM depending on the diff
                _ = diff > 0 ? apptTime = string.Format("{0:h\\:mm} PM", appt.ApptTime.Subtract(TimeSpan.FromHours(12))) : null;
                _ = diff == 0 ? apptTime = string.Format("{0:h\\:mm} PM", appt.ApptTime) : null;
                _ = diff < 0 ? apptTime = string.Format("{0:h\\:mm} AM", appt.ApptTime) : null;


                foreach (Label child in AppointmentTimes.Children) {
                    // If the appTime equals the AppointmentTimes child grid content, then we modify the corresponding 
                    // calendar grid child with the appointment and patient information
                    if (apptTime.CompareTo(child.Content.ToString()) == 0) {
                        // Grab the calendar grid child that matches the same row as the AppointmentTimes grid and colum
                        // that matches the day
                        Label apptLabel = GetChild(AppointmentGrids, Grid.GetRow(child), (int)day - 1) as Label;

                        // Grab the current appt index to be able to get the patient at the same index
                        int index = Appointments.IndexOf(appt);

                        // Grab the patient first name and last name and appointment visit id
                        string firstName = PatientList.ElementAt(index).FirstName;
                        string lastInitial = PatientList.ElementAt(index).LastName;
                        string visitId = appt.VisitId.ToString();

                        // Set the calendar grid child content with the information from above and set the backgroudn to dark green
                        apptLabel.Content = String.Format("{0} {1}.\nVisit Id: {2}", firstName, lastInitial.Substring(0,1), visitId);
                        apptLabel.Background = Brushes.DarkGreen;
                    }
                }
            }
        }

        private void ClearAppointmentGrid() {
            // Clear patient and appointments lists to prepare for new patients and appointments
            Appointments.Clear();
            PatientList.Clear();

            // Return each calendar grid cell to its original color
            foreach (Label child in AppointmentGrids.Children) {
                var bc = new BrushConverter();
                child.Background = (Brush)bc.ConvertFrom("#FF30373E");
                child.Content = String.Empty;
            }
        }

        private static UIElement GetChild(Grid grid, int row, int column) {
            foreach (UIElement child in grid.Children) {
                // Return the child element at the supplied row and column
                if (Grid.GetRow(child) == row && Grid.GetColumn(child) == column) {
                    return child;
                }
            }
            return null;
        }

        private static void HighlightCalendarDay(Grid grid, int row, int column) {
            foreach (Label label in grid.Children) {
                // Check that row and column match the row and column of the selected label
                Boolean labelMatch = Grid.GetRow(label) == row && Grid.GetColumn(label) == column;

                // If it matches, then change the background to #FF4669B0
                // else, return the background to it's default value
                if (labelMatch) {
                    var bc = new BrushConverter();
                    label.Background = (Brush)bc.ConvertFrom("#FF4669B0");
                }
                else {
                    var bc = new BrushConverter();
                    label.Background = (Brush)bc.ConvertFrom("#FF26282C");
                }
            }
        }

        private static void HighlightCalendarCell(Grid grid, int row, int column) {
            foreach (Label child in grid.Children) {
                // Check if the row and column match the row and column of the child element
                Boolean childMatch = Grid.GetRow(child) == row && Grid.GetColumn(child) == column;

                // If it matches, change the margin values, else return them to their original values
                _ = childMatch ? child.Margin = new Thickness(2) : child.Margin = new Thickness(0.5);
            }
        }

        private void ApptDate_MouseDown(object sender, MouseButtonEventArgs e) {
            Label srcLabel = e.Source as Label;

            // Highlight the selected cell and day
            HighlightCalendarCell(AppointmentGrids, Grid.GetRow(srcLabel), Grid.GetColumn(srcLabel));
            HighlightCalendarDay(AppointmentDays, 0, Grid.GetColumn(srcLabel) + 2);

            // Show the selected date on the calendar view
            DateTime date = weekDate.AddDays(Grid.GetColumn(srcLabel) + 1);
            ApptCalendar.SelectedDate = date;

            // Show a new/view appointment button whenever a cell is selected
            ApptButtonGrid.Visibility = Visibility.Visible;
            Boolean srcLabelEmpty = srcLabel.Content.ToString() == String.Empty;
            _ = srcLabelEmpty ? ViewApptButton.Content = "New Appointment" : ViewApptButton.Content = "View Appointment";
        }

        private void ApptDate_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            // Close any new appt windows that are currently active
            if (newApptWindow != null) {
                newApptWindow.Close();
            }

            Label srcLabel = e.Source as Label;

            // Open a new appt window
            OpenAppointmentView(srcLabel);
        }

        private void ViewApptButton_Click(object sender, RoutedEventArgs e) {
            // Close any new appt windows that are currently active
            if (newApptWindow != null) {
                newApptWindow.Close();
            }

            Label srcLabel = null;

            // Create a Thickness object to compare later
            Thickness thc = new Thickness(2);

            // Find the child corresponding to the selected cell on the appointments calendar
            foreach (Label child in AppointmentGrids.Children) {
                // If the marin is 2, then we have found the selected label
                _ = child.Margin.Equals(thc) ? srcLabel = child : null;
            }

            // Open the new appt window
            OpenAppointmentView(srcLabel);
        }

        private void OpenAppointmentView(Label srcLabel) {
            // Get the Label with the row matching the row of the srcLabel
            Label timeLabel = GetChild(AppointmentTimes, Grid.GetRow(srcLabel), 0) as Label;

            // Get the data from the weekDate by adding the column number to the days of that week
            DateTime date = weekDate.AddDays(Grid.GetColumn(srcLabel) + 1);

            // If the srcLabel content is not empty, we want to open the appt window with the current appointment's information
            // else, we want to open a new appt window for adding new appointments
            if (srcLabel.Content.ToString() != String.Empty) {
                // Initialize a patientIndex so that we can find the patient who's appointment has been selected
                int patientIndex = 0;

                // Get the visitId from the srcLabel content
                int visitId = Convert.ToInt32(string.Join("", srcLabel.Content.ToString().ToCharArray().Where(Char.IsDigit)));

                foreach (PatientAppointment appt in Appointments) {
                    // Grab the index of the patient who's visitId matches the visitId in the appointments list
                    if (appt.VisitId == visitId) {
                        patientIndex = Appointments.IndexOf(appt);
                        break;
                    }
                }

                // Grab both the patient and their appointment
                PatientInfo patient = PatientList.ElementAt(patientIndex);
                PatientAppointment appointment = Appointments.ElementAt(patientIndex);

                string firstName = patient.FirstName;
                string lastName = patient.LastName;
                string notes = appointment.ReceptNote;

                /**
                 *  Create a variable to hold this ReceptionistView window to send to the new appt window.
                 *  We want to be able to call the UpdateReceptionistView method from this window when closing the new appt window.
                 */
                ReceptionistView recView = this;

                // Open the new appt window with the patient's information
                newApptWindow = new NewAppointmentWindow(recView, visitId, firstName, lastName, notes, timeLabel, date);
                newApptWindow.Show();
            }
            else {
                // Only do this if the selected date is not today or in the past
                if (DateTime.Compare(date.Date, DateTime.Now.Date) >= 0) {
                    /**
                    *  Create a variable to hold this ReceptionistView window to send to the new appt window.
                    *  We want to be able to call the UpdateReceptionistView method from this window when closing the new appt window.
                    */
                    ReceptionistView recView = this;

                    // Open the new appt window
                    newApptWindow = new NewAppointmentWindow(recView, timeLabel, date);
                    newApptWindow.Show();
                }
            }
        }

        private void SearchPatientBtn_Click(object sender, RoutedEventArgs e) {
            // Update's the billing labels
            UpdateBillingInformation();
        }

        private void UpdateBillingInformation() {
            // Grab the patient with the supplied name
            PatientInfo patient = GetPatientByName();

            // If the patient exists, populate their billing information
            // else, clear the billing information
            if (patient != null) {
                // Set the patients first, last name and id labels
                BillingPatient.Content = patient.FirstName + " " + patient.LastName;
                BillingPatientId.Content = patient.PatientId;

                string balance = string.Format("${0:N2}", patient.Balance);

                // Set the patients balance labels
                BillingPatientBalance.Content = balance;
                BillingOwedAmount.Content = balance;
            }
            else {
                ClearPatientBilling();
            }
        }

        private void ClearPatientBillingBtn_Click(object sender, RoutedEventArgs e) {
            ClearPatientBilling();
        }

        private void ClearPatientBilling() {
            // Set each billing information to the empty string
            BillingFirstNameTb.Text = String.Empty;
            BillingLastNameTb.Text = String.Empty;
            BillingPatient.Content = String.Empty;
            BillingPatientId.Content = String.Empty;
            BillingPatientBalance.Content = String.Empty;
            BillingOwedAmount.Content = String.Empty;
            BillingPayAmount.Text = String.Empty;
            BillingChange.Content = String.Empty;
        }

        private void PayPatientBillingBtn_Click(object sender, RoutedEventArgs e) {
            // Only do this if a valid patient has been selected
            if (BillingPatientId.Content.ToString() != String.Empty) {
                // Grab the amount owed by the patient
                decimal oweAmount = Convert.ToDecimal(BillingOwedAmount.Content.ToString().Substring(1));

                if (oweAmount > 0) {
                    // Send the amount owed to the verification step
                    PaymentVerificationHandling(oweAmount);
                }
            }
        }

        private void PaymentVerificationHandling(decimal oweAmount) {
            if (IsValidPayment()) {
                // Grab the amount the patient wishes to pay to two decimal places ({0:N2})
                string stringPayAmount = string.Format("{0:N2}", Convert.ToDecimal(BillingPayAmount.Text)).Trim(' ');
                
                // Convert the amount to be paid into a decimal value
                decimal payAmount = Convert.ToDecimal(stringPayAmount);

                decimal amountPaid = 0;

                // If the amount paid is less than the owed amount, then set amountPaid equal to payAmount
                // else, set amountPaid equal to payAmount minus oweAmount. (So that the patient can't overpay)
                _ = oweAmount > payAmount ? (amountPaid = payAmount, null) : (amountPaid = oweAmount, BillingChange.Content = "$" + (payAmount - oweAmount).ToString());

                // Grab the patient Id from the billing information
                int patientId = Convert.ToInt32(new String(BillingPatientId.Content.ToString().Where(Char.IsDigit).ToArray()).Trim(' '));

                // Go to payment confirmation and update the billing information
                ConfirmPayment(patientId, amountPaid);
                UpdateBillingInformation();
            }
            else {
                MessageBox.Show("Invalid payment.");
            }
        }

        private Boolean IsValidPayment() {
            //bool isValid = true;
            /** 
             *  Payment is only valid if the text contains only digits and decimals
             *  (I realize more needs to be done to ensure a valid input but I needed to spend
             *  more time on the rest of the project)
             */
            //_ = !Regex.IsMatch(BillingPayAmount.Text, @"^[0-9.]+$") ? isValid = false : true;

            return Regex.IsMatch(BillingPayAmount.Text, @"^[0-9.]+$");
            //return isValid;
        }

        private void ConfirmPayment(int patientId, Decimal amountPaid) {
            // Set the payment confirmation dialog box
            string confirmation = "Confirm payment amount of " + amountPaid.ToString() + "?";
            MessageBoxResult result = MessageBox.Show(confirmation, "Payment Confirmation", MessageBoxButton.YesNo);

            switch (result) {
                case MessageBoxResult.Yes:
                    // Set the pay amount text to empty and update the patients balance in the database
                    BillingPayAmount.Text = String.Empty;
                    UpdateDbPatientBalance(patientId, Decimal.Negate(amountPaid));
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void NextPrevWeekBtn_Click(object sender, RoutedEventArgs e) {
            Button btn = e.Source as Button;

            // Get the date selected on the appt calendar
            DateTime date = (DateTime)ApptCalendar.SelectedDate;

            // Proceed to the next week or previous week based on the button pressed
            if (btn.Content.ToString() == "Next") {
                ApptCalendar.SelectedDate = date.AddDays(7);
                ApptCalendar.DisplayDate = date.AddDays(7);
            }
            else {
                ApptCalendar.SelectedDate = date.AddDays(-7);
                ApptCalendar.DisplayDate = date.AddDays(-7);
            }
        }
    }
}