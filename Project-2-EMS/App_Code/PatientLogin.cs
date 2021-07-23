using System;

namespace Project_2_EMS {
  class PatientLogin {
    private int Id { get; }
    internal String Username { get; }
    internal String Password { get; }
    internal int PatientId { get; }

    public PatientLogin(int id, String username, String password, int patientId) {
      Id = id;
      Username = username;
      Password = password;
      PatientId = patientId;
    }
  }
}
