using System;
using System.Collections.Generic;

namespace SimpleConnectio.Models;

public partial class Smartphone
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Model { get; set; } = null!;
}
