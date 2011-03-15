﻿namespace SharpArch.Domain.DomainModel
{
    using System;
    using System.Collections.Generic;

    using SharpArch.Domain.CommonValidator;

    [Serializable]
    public abstract class ValidatableObject : BaseObject, IValidatable
    {
        private static IValidator Validator
        {
            get
            {
                return SafeServiceLocator<IValidator>.GetService();
            }
        }

        public virtual bool IsValid()
        {
            return Validator.IsValid(this);
        }

        public virtual ICollection<IValidationResult> ValidationResults()
        {
            return Validator.ValidationResultsFor(this);
        }
    }
}