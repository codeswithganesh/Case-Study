using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnect.Repository
{
    internal class NotifcationService
    {
        readonly ReservationRepository _reservationRepository;

        public NotifcationService(ReservationRepository _reservationRepository)
        {
            _reservationRepository = new  ReservationRepository();

            // Subscribe to events
            _reservationRepository.ReservationConfirmedSMS += SendSMSNotification;
            _reservationRepository.ReservationConfirmedEmail += SendEmailNotification;
            _reservationRepository.ReservationCancelledSMS += SendSMSNotification;
            _reservationRepository.ReservationCancelledEmail += SendEmailNotification;
            _reservationRepository.ReservationUpdatedSMS += SendSMSNotification;
            _reservationRepository.ReservationUpdatedEmail += SendEmailNotification;
        }
       

        
        private void SendSMSNotification(string phoneNumber, string message)
        {
            Console.WriteLine($"Sending SMS notification to {phoneNumber}: {message}");
        }

        // Event handler for sending email notifications
        private void SendEmailNotification(string email, string subject, string body)
        {
            // Logic to send email notification
        }
    }
}
