using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xolit.Api.Services.Command.Authentication
{
    public interface ICreateTokenCommand
    {
        string CreateToken();
    }
}
