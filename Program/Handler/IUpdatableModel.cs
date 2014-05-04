﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Modelizer.Repositories;

namespace Program.Handler {
	public interface IUpdatableModel {
		void Update(Repository Repository);
	}
}
