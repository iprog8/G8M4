namespace FirstMvcApp.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Translation
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Lang { get; set; }
        public string Text { get; set; }
    }
}