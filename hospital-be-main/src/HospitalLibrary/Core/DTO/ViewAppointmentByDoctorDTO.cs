﻿
using HospitalLibrary.Core.Enum;
using HospitalLibrary.Core.Model;
using System;


namespace HospitalLibrary.Core.DTO
{
    public class ViewAppointmentByDoctorDTO
    {
        public Guid PatientId { get; set; }
        public Status Status { get; set; }
        public string PatientName { get; set; }
        public Guid AppointmentId { get; set; }
        public DateRange Date { get; set; }

        public ViewAppointmentByDoctorDTO(Appointment app)
        {
            PatientId = app.PatientId;
            Status = app.Status;
            Date = app.Range;
            AppointmentId = app.Id;
            PatientName = app.Patient.Name + ' ' + app.Patient.Surname;
        }
    }
}
