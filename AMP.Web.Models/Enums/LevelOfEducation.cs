using System.Collections.Generic;
using System.Diagnostics;

namespace AMP.Web.Models.Enums
{
    public enum LevelOfEducation
    {
        Jhs = 1,
        Shs,
        Undergraduate,
        Masters,
        PhD
    }

    public static class Education
    {
        public static readonly List<(int, string)> Levels = new List<(int, string)>()
        {
            (1, "Jhs"),
            (2, "Shs"),
            (3, "Undergraduate"),
            (4, "Masters"),
            (5, "PhD")
        };
    }
}