using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herramienta
{
    public static class Seguridad
    {
        public static bool sessionActiva(Object session)
        {
            Usuario user = session != null ? (Usuario)session : null;
            if (user != null && user.Id != 0)
                return true;
            else 
                return false;
        }
        public static bool isAdmin(Object session) 
        {
            Usuario user = session != null ? (Usuario)session : null;
            return user != null ? user.Admin : false;
        }
    }
}
