namespace Project_2_EMS.Models.DatabaseModels {
    interface ITableQueryStrings {
        string Delete(string queryBy);
        string Insert();
        string Select(string queryBy);
        string Update(string queryBy);
    }
}
