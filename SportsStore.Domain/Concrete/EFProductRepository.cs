﻿using SportsStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Concrete
{
	public class EFProductRepository : IProductRepository
	{
		private EFDbContext _context = new EFDbContext();
		public IQueryable<Entities.Product> Products
		{
			get 
			{
				return _context.Products;
			}
		}
	}
}
