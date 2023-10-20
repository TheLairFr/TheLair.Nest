﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLair.Nest.Domain;

public class Solution
{
    public string GithubURL { get; set; } = String.Empty;
    public string LocalProjectPath { get; set; } = String.Empty;
    public List<Project> Projects { get; set; } = new List<Project>();
}