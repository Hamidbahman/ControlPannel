using System;

namespace controlpannel.application.Dtos.RoleDtos;

public class RoleSortingDto
{
        public long ApplicationId { get; set; }

        public string? SortByField { get; set; }
        public bool Descending { get; set; }
}
