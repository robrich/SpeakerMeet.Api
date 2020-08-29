﻿using System;

namespace SpeakerMeet.Core.DTOs
{
    public class ConferencesResult
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Slug { get; set; } = null!;

        public string Location { get; set; } = null!;

        public string Description { get; set; } = null!;

        public PaginationInfo PaginationInfo { get; set; } = default!;
    }
}
