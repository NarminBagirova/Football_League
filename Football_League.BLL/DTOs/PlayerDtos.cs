using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.BLL.DTOs
{
    public class PlayerDtos
    {
        public record PlayerDto(int Id, string FirstName, string LastName, int TeamId, int Goals, int ShirtNumber);
        public record PlayerSaveDto(string FirstName, string LastName, int TeamId, int ShirtNumber);
    }

}
