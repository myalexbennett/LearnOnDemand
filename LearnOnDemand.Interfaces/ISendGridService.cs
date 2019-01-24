using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearnOnDemand.Interfaces
{
    public interface ISendGridService
    {
        Task SendMail(string to, string email);
    }
}
