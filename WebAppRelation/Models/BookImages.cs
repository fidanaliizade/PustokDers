﻿namespace WebAppRelation.Models
{
    public class BookImages
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        public Book Book { get; set; }
    }
}
