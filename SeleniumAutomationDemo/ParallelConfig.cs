using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
[assembly: Parallelizable(ParallelScope.Fixtures)] // parallelize classes only
[assembly: LevelOfParallelism(3)]                   // cap total workers at 3