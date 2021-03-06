﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Skinet.API.Dtos
{
    public class CustomerBasketDto
    {
        public CustomerBasketDto()
        {

        }

        public CustomerBasketDto(string id)
        {
            Id = id;
        }

        [Required]
        public string Id { get; set; }

        public List<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();
    }
}
