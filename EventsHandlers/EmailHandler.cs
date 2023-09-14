using ApiMediator.Notifications;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ApiMediator.EventsHandlers
{
    //Qualquer notificação ref. ao customer em nosso sistema, a classe EmailHandler receberá a notificação
    // e fará a execução do processo
    public class EmailHandler : INotificationHandler<CustomerActionNotification>
    {
        public Task Handle(CustomerActionNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                //ao invés de disparar e-mail, fazemos uma simulação com o console
                Console.WriteLine("O cliente {0} {1} foi {2} com sucesso", notification.FirstName, notification.LastName, notification.Action.ToString().ToLower());
            });
        }
    }
}
