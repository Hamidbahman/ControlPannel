using System;

namespace controlpannel.application.Dtos;

    public class AplicationSortingRequestDto
    {
        public string? SortByField { get; set; }
        public bool Descending { get; set; }
    }