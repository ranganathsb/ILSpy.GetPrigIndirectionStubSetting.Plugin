﻿/* 
 * File: ReflectionMethodIdConversionFactory.cs
 * 
 * Author: Akira Sugiura (urasandesu@gmail.com)
 * 
 * 
 * Copyright (c) 2016 Akira Sugiura
 *  
 *  This software is MIT License.
 *  
 *  Permission is hereby granted, free of charge, to any person obtaining a copy
 *  of this software and associated documentation files (the "Software"), to deal
 *  in the Software without restriction, including without limitation the rights
 *  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 *  copies of the Software, and to permit persons to whom the Software is
 *  furnished to do so, subject to the following conditions:
 *  
 *  The above copyright notice and this permission notice shall be included in
 *  all copies or substantial portions of the Software.
 *  
 *  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 *  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 *  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 *  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 *  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 *  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 *  THE SOFTWARE.
 */



using Mono.Cecil;
using System;

namespace ILSpy.GetPrigIndirectionStubSetting.Plugin
{
    class ReflectionMethodIdConversionFactory
    {
        public static ReflectionMethodIdConversion New(MemberReference member)
        {
            {
                var methodDef = member as MethodDefinition;
                if (methodDef != null)
                    return new MethodDefinitionConversion(methodDef);
            }
            {
                var propDef = member as PropertyDefinition;
                if (propDef != null)
                    return new PropertyDefinitionConversion(propDef);
            }
            {
                var eventDef = member as EventDefinition;
                if (eventDef != null)
                    return new EventDefinitionConversion(eventDef);
            }

            throw new NotSupportedException(string.Format("The specified member type \"{0}\" is not supported.", member.GetType()));
        }
    }
}
