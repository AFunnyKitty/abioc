﻿// Copyright (c) 2017 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Abioc
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Extension methods on <see cref="ConstructionContext{TExtra}"/>.
    /// </summary>
    public static class ConstructionContextExtensions
    {
        /// <summary>
        /// Creates a <see cref="ConstructionContext{TExtra}"/> updated with the <paramref name="extra"/> information.
        /// </summary>
        /// <typeparam name="TExtra">
        /// The type of the <see cref="ConstructionContext{TExtra}.Extra"/> construction context information.
        /// </typeparam>
        /// <param name="context">The source <see cref="ConstructionContext{TExtra}"/>.</param>
        /// <param name="extra">
        /// The <see cref="ConstructionContext{TExtra}.Extra"/> construction context information.
        /// </param>
        /// <returns>An updated <see cref="ConstructionContext{TExtra}"/>.</returns>
        public static ConstructionContext<TExtra> Initialize<TExtra>(
            this ConstructionContext<TExtra> context,
            TExtra extra)
        {
            return new ConstructionContext<TExtra>(
                context.ImplementationType,
                context.ServiceType,
                context.RecipientType,
                extra);
        }

        /////// <summary>
        /////// Creates a <see cref="ConstructionContext{TExtra}"/> updated with the specified parameters.
        /////// </summary>
        /////// <typeparam name="TExtra">
        /////// The type of the <see cref="ConstructionContext{TExtra}.Extra"/> construction context information.
        /////// </typeparam>
        /////// <param name="context">The source <see cref="ConstructionContext{TExtra}"/>.</param>
        /////// <param name="implementationType">The <see cref="ConstructionContext{TExtra}.ImplementationType"/>.</param>
        /////// <param name="serviceType">The <see cref="ConstructionContext{TExtra}.ServiceType"/>.</param>
        /////// <param name="recipientType">The <see cref="ConstructionContext{TExtra}.RecipientType"/>.</param>
        /////// <returns>An updated <see cref="ConstructionContext{TExtra}"/>.</returns>
        ////public static ConstructionContext<TExtra> Update<TExtra>(
        ////    this ConstructionContext<TExtra> context,
        ////    Type implementationType = null,
        ////    Type serviceType = null,
        ////    Type recipientType = null)
        ////{
        ////    return new ConstructionContext<TExtra>(
        ////        implementationType ?? context.ImplementationType,
        ////        serviceType ?? context.ServiceType,
        ////        recipientType ?? context.RecipientType,
        ////        context.Extra);
        ////}
    }
}