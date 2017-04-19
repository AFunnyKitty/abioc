﻿// Copyright (c) 2017 James Skimming. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Abioc
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Abioc.AbstractDependencies;
    using FluentAssertions;
    using Xunit;

    namespace AbstractDependencies
    {
        public interface IInterface
        {
        }

        public abstract class AbstractBaseClass
        {
        }

        public class InterfaceImplementation : IInterface
        {
        }

        public class BaseClassImplementation : AbstractBaseClass
        {
        }

        public class BothImplementation : AbstractBaseClass, IInterface
        {
        }

        public class ClassWithInterfaceDependencies
        {
            public ClassWithInterfaceDependencies(IInterface interfaceDependency)
            {
                InterfaceDependency =
                    interfaceDependency ?? throw new ArgumentNullException(nameof(interfaceDependency));
            }

            public IInterface InterfaceDependency { get; }
        }

        public class ClassWithAbstractBaseClassDependencies
        {
            public ClassWithAbstractBaseClassDependencies(AbstractBaseClass abstractBaseClassDependency)
            {
                AbstractBaseClassDependency =
                    abstractBaseClassDependency
                    ?? throw new ArgumentNullException(nameof(abstractBaseClassDependency));
            }

            public AbstractBaseClass AbstractBaseClassDependency { get; }
        }

        public class ClassWithMixedDependencies
        {
            public ClassWithMixedDependencies(
                IInterface interfaceDependency,
                AbstractBaseClass abstractBaseClassDependency,
                InterfaceImplementation interfaceImplementation,
                BaseClassImplementation baseClassImplementation)
            {
                InterfaceDependency =
                    interfaceDependency ?? throw new ArgumentNullException(nameof(interfaceDependency));
                AbstractBaseClassDependency =
                    abstractBaseClassDependency
                    ?? throw new ArgumentNullException(nameof(abstractBaseClassDependency));
                InterfaceImplementation =
                    interfaceImplementation ?? throw new ArgumentNullException(nameof(interfaceImplementation));
                BaseClassImplementation =
                    baseClassImplementation ?? throw new ArgumentNullException(nameof(baseClassImplementation));
            }

            public IInterface InterfaceDependency { get; }
            public AbstractBaseClass AbstractBaseClassDependency { get; }
            public InterfaceImplementation InterfaceImplementation { get; }
            public BaseClassImplementation BaseClassImplementation { get; }
        }
    }

    public class WhenRegisteringAbstractDependencies
    {
        private readonly CompilationContext<DefaultContructionContext> _context;

        public WhenRegisteringAbstractDependencies()
        {
            _context = new RegistrationContext<DefaultContructionContext>()
                .Register<IInterface, InterfaceImplementation>()
                .Register<AbstractBaseClass, BaseClassImplementation>()
                .Register<ClassWithInterfaceDependencies>()
                .Register<ClassWithAbstractBaseClassDependencies>()
                .Register<ClassWithMixedDependencies>()
                .Compile(GetType().GetTypeInfo().Assembly);
        }

        [Fact]
        public void ItShouldCreateAClassWithInterfaceDependencies()
        {
            // Act
            ClassWithInterfaceDependencies actual = _context.GetService<ClassWithInterfaceDependencies>();

            // Assert
            actual.Should().NotBeNull();
            actual.InterfaceDependency
                .Should()
                .NotBeNull()
                .And.BeOfType<InterfaceImplementation>();
        }

        [Fact]
        public void ItShouldCreateAClassWithAbstractBaseClassDependencies()
        {
            // Act
            ClassWithAbstractBaseClassDependencies actual =
                _context.GetService<ClassWithAbstractBaseClassDependencies>();

            // Assert
            actual.Should().NotBeNull();
            actual.AbstractBaseClassDependency
                .Should()
                .NotBeNull()
                .And.BeOfType<BaseClassImplementation>();
        }

        [Fact]
        public void ItShouldCreateAClassWithMixedDependencies()
        {
            // Act
            ClassWithMixedDependencies actual =
                _context.GetService<ClassWithMixedDependencies>();

            // Assert
            actual.Should().NotBeNull();
            actual.InterfaceDependency
                .Should()
                .NotBeNull()
                .And.BeOfType<InterfaceImplementation>();
            actual.AbstractBaseClassDependency
                .Should()
                .NotBeNull()
                .And.BeOfType<BaseClassImplementation>();

            actual.InterfaceImplementation
                .Should()
                .NotBeNull()
                .And.BeOfType<InterfaceImplementation>()
                .And.NotBeSameAs(actual.InterfaceDependency);

            actual.BaseClassImplementation
                .Should()
                .NotBeNull()
                .And.BeOfType<BaseClassImplementation>()
                .And.NotBeSameAs(actual.AbstractBaseClassDependency);
        }
    }

    public class WhenRegisteringAClassThatImplementsMultipleAbstractions
    {
        private readonly CompilationContext<DefaultContructionContext> _context;

        public WhenRegisteringAClassThatImplementsMultipleAbstractions()
        {
            _context = new RegistrationContext<DefaultContructionContext>()
                .Register<IInterface, BothImplementation>()
                .Register<AbstractBaseClass, BothImplementation>()
                .Register<InterfaceImplementation>()
                .Register<BaseClassImplementation>()
                .Register<ClassWithInterfaceDependencies>()
                .Register<ClassWithAbstractBaseClassDependencies>()
                .Register<ClassWithMixedDependencies>()
                .Compile(GetType().GetTypeInfo().Assembly);
        }

        [Fact]
        public void ItShouldCreateAClassWithInterfaceDependencies()
        {
            // Act
            ClassWithInterfaceDependencies actual = _context.GetService<ClassWithInterfaceDependencies>();

            // Assert
            actual.Should().NotBeNull();
            actual.InterfaceDependency
                .Should()
                .NotBeNull()
                .And.BeOfType<BothImplementation>();
        }

        [Fact]
        public void ItShouldCreateAClassWithAbstractBaseClassDependencies()
        {
            // Act
            ClassWithAbstractBaseClassDependencies actual =
                _context.GetService<ClassWithAbstractBaseClassDependencies>();

            // Assert
            actual.Should().NotBeNull();
            actual.AbstractBaseClassDependency
                .Should()
                .NotBeNull()
                .And.BeOfType<BothImplementation>();
        }

        [Fact]
        public void ItShouldCreateAClassWithMixedDependencies()
        {
            // Act
            ClassWithMixedDependencies actual =
                _context.GetService<ClassWithMixedDependencies>();

            // Assert
            actual.Should().NotBeNull();
            actual.InterfaceDependency
                .Should()
                .NotBeNull()
                .And.BeOfType<BothImplementation>();
            actual.AbstractBaseClassDependency
                .Should()
                .NotBeNull()
                .And.BeOfType<BothImplementation>();

            actual.InterfaceImplementation
                .Should()
                .NotBeNull()
                .And.BeOfType<InterfaceImplementation>()
                .And.NotBeSameAs(actual.InterfaceDependency);

            actual.BaseClassImplementation
                .Should()
                .NotBeNull()
                .And.BeOfType<BaseClassImplementation>()
                .And.NotBeSameAs(actual.AbstractBaseClassDependency);
        }
    }
}
