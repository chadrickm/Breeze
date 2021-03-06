﻿using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Breeze.TumbleBit.Models
{
    /// <summary>
    /// Base class for request objects received to the controllers
    /// </summary>
    public class RequestModel
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }

    /// <summary>
    /// Object used to connect to a tumbler.
    /// </summary>
    public class TumblerConnectionRequest : RequestModel
    {
        [Required(ErrorMessage = "A server address is required.")]
        public Uri ServerAddress { get; set; }

        public string Network { get; set; }
    }
}
