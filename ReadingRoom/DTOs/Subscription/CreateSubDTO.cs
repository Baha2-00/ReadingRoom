﻿namespace ReadingRoom.DTOs.Subscription
{
    public class CreateSubDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public float durationInDays { get; set; }
        public int DownloadedBookAmount { get; set; }
    }
}
