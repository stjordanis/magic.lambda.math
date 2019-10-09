﻿/*
 * Magic, Copyright(c) Thomas Hansen 2019 - thomas@gaiasoul.com
 * Licensed as Affero GPL unless an explicitly proprietary license has been obtained.
 */

using System;
using System.Linq;
using System.Collections.Generic;
using magic.node;
using magic.node.extensions;

namespace magic.lambda.math.utilities
{
    internal static class Utilities
    {
        public static dynamic GetBase(Node node)
        {
            if (node.Value != null)
                return node.GetEx<dynamic>() ?? throw new ArgumentNullException("No base number found during calculation attempt");
            return node.Children.FirstOrDefault()?.GetEx<dynamic>() ?? throw new ArgumentNullException("No base number found during calculation attempt");
        }

        public static IEnumerable<dynamic> AllButBase(Node node)
        {
            if (node.Value != null)
                return node.Children.Select(x => x.GetEx<dynamic>());
            return node.Children.Skip(1).Select(x => x.GetEx<dynamic>());
        }
    }
}