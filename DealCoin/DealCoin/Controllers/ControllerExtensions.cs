﻿using System;
using DealCoin.Services;
using Microsoft.AspNetCore.Mvc;

namespace DealCoin.Controllers
{
    public static class ControllerExtensions
    {
        public static IActionResult CreateResult<T>( this Controller @this, Result<T> result )
        {
            return CreateResult( @this, result, new ActionResultOptions<T, object>( @this ) );
        }

        public static IActionResult CreateResult<T, TViewModel>(
            this Controller @this,
            Result<T> result,
            ActionResultOptions<T, TViewModel> options )
        {
            object value;
            if( !result.HasError && options.ToViewModel != null ) value = options.ToViewModel( result.Content );
            else if( !result.HasError ) value = result.Content;
            else value = result.ErrorMessage;

            if( result.Status == Status.Ok ) return @this.Ok( value );
            if( result.Status == Status.NotFound ) return @this.NotFound( value );
            if( result.Status == Status.BadRequest ) return @this.BadRequest( value );
            if( result.Status == Status.Created )
            {
                return @this.CreatedAtRoute( options.RouteName, options.RouteValues( result.Content ), value );
            }

            throw new ArgumentException( "Unknown status.", nameof( result ) );
        }

        public static IActionResult CreateResult<T, TViewModel>(
            this Controller @this,
            Result<T> result,
            Action<ActionResultOptions<T, TViewModel>> options )
        {
            ActionResultOptions<T, TViewModel> o = new ActionResultOptions<T, TViewModel>( @this );
            options( o );
            return @this.CreateResult( result, o );
        }

        public static IActionResult CreateResult( this Controller @this, Result result )
        {
            if( result.Status == Status.Ok ) return @this.Ok();
            if( result.Status == Status.NotFound ) return @this.NotFound( result.ErrorMessage );
            if( result.Status == Status.BadRequest ) return @this.BadRequest( result.ErrorMessage );

            throw new ArgumentException( "Unknown status.", nameof( result ) );
        }
    }
}
