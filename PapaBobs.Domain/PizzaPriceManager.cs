﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobs.Domain
{
    public class PizzaPriceManager
    {
        public static decimal CalculateCost(DTO.OrderDTO order)
        {
            decimal cost = 0M;
            var prices = getPizzaPrices();

            cost += calculateSizeCost(order, prices);
            cost += calculateCrustCost(order, prices);
            cost += calculateTopping(order, prices);

            return cost;
        }

        private static DTO.PizzaPriceDTO getPizzaPrices()
        {
            var prices = Persistence.PizzaPriceRepository.GetPizzaPrices();
            return prices;
        }

        private static decimal calculateSizeCost(DTO.OrderDTO order, DTO.PizzaPriceDTO prices)
        {
            decimal cost = 0;

            switch (order.Size)
            {
                case DTO.Enums.SizeType.Small:
                    cost = prices.SmallSizeCost;
                    break;
                case DTO.Enums.SizeType.Medium:
                    cost = prices.MediumSizeCost;
                    break;
                case DTO.Enums.SizeType.Large:
                    cost = prices.LargeSizeCost;
                    break;
                default:
                    break;
            }

            return cost;        
        }

        private static decimal calculateCrustCost(DTO.OrderDTO order, DTO.PizzaPriceDTO prices)
        {
            decimal cost = 0;

            switch (order.Crust)
            {
                case DTO.Enums.CrustType.Thin:
                    cost = prices.ThinCrustCost;
                    break;
                case DTO.Enums.CrustType.Regular:
                    cost = prices.RegularCrustCost;
                    break;
                case DTO.Enums.CrustType.Thick:
                    cost = prices.ThickCrustCost;
                    break;
                default:
                    break;
            }

            return cost;
        }

        private static decimal calculateTopping(DTO.OrderDTO order, DTO.PizzaPriceDTO prices)
        {
            decimal cost = 0;

            cost += (order.Sausage) ? prices.SausageCost : 0M;
            cost += (order.Pepperoni) ? prices.PepperoniCost : 0M;
            cost += (order.Onions) ? prices.OnionsCost : 0M;
            cost += (order.GreenPeppers) ? prices.GreenPeppersCost : 0M;

            return cost;
        }

    }
}
