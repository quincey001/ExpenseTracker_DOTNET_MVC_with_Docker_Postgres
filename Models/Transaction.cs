﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Models
{
	public class Transaction
	{
		[Key]
		public int TransactionId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage ="Please select a category.")]
		public int CategoryId { get; set; }

		public Category? Category{ get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Amount should be greater than 0.")]
        public int Amount{ get; set; }

        [Column(TypeName = "varchar(75)")]
        public string? Note { get; set; }

        public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;

       
        public string? CategoryTitleWithIcon
        {
            get
            {
                return Category == null ? "" : Category.Icon + " " + Category.Title;
            }
        }
        [NotMapped]
        public string? FormattedAmount
        {
            get
            {
                return ((Category == null || Category.Type == "Expense") ? "- " : "+ ") + Amount.ToString();
            }
        }

    }
}

