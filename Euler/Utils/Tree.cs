// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Utils
{
    using System.Collections.Generic;

    public class Tree
    {
        private readonly int _valeur;
        private readonly HashSet<Tree> _sons;
        private long? _minPathValue;
        private long? _maxPathValue;

        public Tree(int value)
        {
            _valeur = value;
            _minPathValue = null;
            _maxPathValue = null;
            _sons = new HashSet<Tree>();
        }

        public void AddSon(Tree son)
        {
            _sons.Add(son);
            ResetPathValues();
        }

        public long GetMaxPath()
        {
            if (!_maxPathValue.HasValue)
            {
                _maxPathValue = ComputeMaxPath();
            }

            return _maxPathValue.Value;
        }

        private void ResetPathValues()
        {
            _minPathValue = null;
            _maxPathValue = null;
        }

        public long GetMinPath()
        {
            if (!_minPathValue.HasValue)
            {
                _minPathValue = ComputeMinPath();
            }

            return _minPathValue.Value;
        }
        
        private long ComputeMaxPath()
        {
            long max = 0;
            foreach (Tree son in _sons)
            {
                long sonValue = son.GetMaxPath();
                if (sonValue > max)
                {
                    max = sonValue;
                }
            }
            
            return _valeur + max;
        }

        private long ComputeMinPath()
        {
            long? min = null;
            foreach (Tree son in _sons)
            {
                long sonValue = son.GetMinPath();
                if (min == null || sonValue < min)
                {
                    min = sonValue;
                }
            }

            return _valeur + (min ?? 0);
        }
    }
}