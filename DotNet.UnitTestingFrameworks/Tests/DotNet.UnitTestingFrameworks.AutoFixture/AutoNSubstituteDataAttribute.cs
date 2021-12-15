﻿using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.NUnit3;

namespace DotNet.UnitTestingFrameworks.AutoFixture
{
    public class AutoNSubstituteDataAttribute : AutoDataAttribute
    {
        public AutoNSubstituteDataAttribute()
            : base(() => new Fixture().Customize(new AutoNSubstituteCustomization()))
        {

        }
    }
}
