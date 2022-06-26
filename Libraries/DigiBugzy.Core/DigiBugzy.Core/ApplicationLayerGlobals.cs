global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using System.Threading.Tasks;
global using System.Collections;
global using System.Reflection;
global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;
global using System.Text.Json.Serialization;

global using FluentMigrator;
global using AutoMapper;
global using MediatR;
global using Microsoft.Extensions.DependencyInjection;


global using DigiBugzy.ApplicationLayer.Enumerations;
global using DigiBugzy.ApplicationLayer.Common.Mappings;
global using DigiBugzy.ApplicationLayer.CommandHandlers.Products;
global using DigiBugzy.ApplicationLayer.CommandHandlers.Products.Commands;
global using DigiBugzy.ApplicationLayer.CommandHandlers.Products.Queries;
global using DigiBugzy.ApplicationLayer.CommandHandlers.Products.Queries.GetAllProducts;
global using DigiBugzy.ApplicationLayer.CommandHandlers.Products.Commands.CreateProduct;

global using DigiBugzy.Domain.Constants;
global using DigiBugzy.Domain.Entities.xBase.Interfaces;
global using DigiBugzy.Domain.Entities.xBase;
global using DigiBugzy.Domain.Entities.Administration;
global using DigiBugzy.Domain.Entities.Administration.Categories;
global using DigiBugzy.Domain.Entities.Administration.CustomFields;
global using DigiBugzy.Domain.Entities.Administration.Classifications;
global using DigiBugzy.Domain.Entities.Products;
global using DigiBugzy.Domain.Entities.Projects;
global using DigiBugzy.Domain.Entities.Administration.Notes;
global using DigiBugzy.Domain.Helpers;
global using DigiBugzy.Domain.Entities.Administration.DigiAdmins;
global using DigiBugzy.Domain.Entities.Secures;



namespace DigiBugzy.ApplicationLayer
{
    public static class ApplicationLayerGlobals
    {
    }
}
