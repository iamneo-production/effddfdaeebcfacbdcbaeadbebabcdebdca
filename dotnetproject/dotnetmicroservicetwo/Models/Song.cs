using System;
using System.Collections.Generic;

namespace dotnetmicroserviceone.Models;
public class Song
{
    public int SongID { get; set; }
    public string SongName { get; set; }
    public string ReleaseYear { get; set; }
    public string SingerName { get; set; }
}