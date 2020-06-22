﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Models
{
    public class ApiError
    {
        public const string ModelBindingErrorMessage = "Invalid parameters.";

        public ApiError()
        {
        }

        public ApiError(string message)
        {
            Message = message;
        }

        
        public ApiError(ModelStateDictionary modelState)
        {
            Message = ModelBindingErrorMessage;

            Detail = modelState
                .FirstOrDefault(x => x.Value.Errors.Any())
                .Value?.Errors?.FirstOrDefault()?.ErrorMessage;
        }

        public string Message { get; set; }

        public string Detail { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        [DefaultValue("")]
        public string StackTrace { get; set; }
    }
}
