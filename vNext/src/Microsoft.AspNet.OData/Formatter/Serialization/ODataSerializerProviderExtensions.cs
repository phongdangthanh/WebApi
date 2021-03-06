﻿// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License.  See License.txt in the project root for license information.

using System.Diagnostics.Contracts;
using Microsoft.AspNet.Http;
using Microsoft.OData.Edm;

namespace Microsoft.AspNet.OData.Formatter.Serialization
{
    internal static class ODataSerializerProviderExtensions
    {
        public static ODataEdmTypeSerializer GetEdmTypeSerializer(this ODataSerializerProvider serializerProvider,
            IEdmModel model, object instance, HttpRequest request)
        {
            Contract.Assert(serializerProvider != null);
            Contract.Assert(model != null);
            Contract.Assert(instance != null);

            Contract.Assert(instance != null);

            IEdmObject edmObject = instance as IEdmObject;
            if (edmObject != null)
            {
                return serializerProvider.GetEdmTypeSerializer(edmObject.GetEdmType());
            }

            return serializerProvider.GetODataPayloadSerializer(model, instance.GetType(), request) as ODataEdmTypeSerializer;
        }
    }
}
