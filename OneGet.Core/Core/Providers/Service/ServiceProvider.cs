// 
//  Copyright (c) Microsoft Corporation. All rights reserved. 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//  http://www.apache.org/licenses/LICENSE-2.0
//  
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//  

namespace Microsoft.OneGet.Core.Providers.Service {
    using System;
    using System.Collections.Generic;
    using Dynamic;
    using Extensions;
    using Package;
    using Callback = System.Object;

    internal class ServicesProvider : ProviderBase<IServicesProvider> {
        private string _name;

        internal ServicesProvider(IServicesProvider provider) : base(provider) {
        }

        public override string Name {
            get {
                return _name ?? (_name = Provider.GetServicesProviderName());
            }
        }
        
        public void DownloadFile(Uri remoteLocation, string localFilename, Callback c) {
            Provider.DownloadFile(remoteLocation, localFilename, c.Extend<IRequest>(Context));
        }

        public bool IsSupportedArchive(string localFilename, Callback c) {
            return Provider.IsSupportedArchive(localFilename, c.Extend<IRequest>(Context));
        }

        public IEnumerable<string> UnpackArchive(string localFilename, string destinationFolder, Callback c) {
            return Provider.UnpackArchive(localFilename, destinationFolder, c.Extend<IRequest>(Context)).ByRefEnumerable();
        }

        public void AddPinnedItemToTaskbar(string item, Callback c) {
            Provider.AddPinnedItemToTaskbar(item, c.Extend<IRequest>(Context));
        }

        public void RemovePinnedItemFromTaskbar(string item, Callback c) {
            Provider.RemovePinnedItemFromTaskbar(item, c.Extend<IRequest>(Context));
        }

        public void CreateShortcutLink(string linkPath, string targetPath, string description, string workingDirectory, string arguments, Callback c) {
            Provider.CreateShortcutLink(linkPath, targetPath, description, workingDirectory, arguments, c.Extend<IRequest>(Context));
        }

        public void SetEnvironmentVariable(string variable, string value, int context, Callback c) {
            Provider.SetEnvironmentVariable(variable, value, context, c.Extend<IRequest>(Context));
        }

        public void RemoveEnvironmentVariable(string variable, int context, Callback c) {
            Provider.RemoveEnvironmentVariable(variable, context, c.Extend<IRequest>(Context));
        }

        public void CopyFile(string sourcePath, string destinationPath, Callback c) {
            Provider.CopyFile(sourcePath, destinationPath, c.Extend<IRequest>(Context));
        }

        public void Delete(string path, Callback c) {
            Provider.Delete(path, c.Extend<IRequest>(Context));
        }

        public void DeleteFolder(string folder, Callback c) {
            Provider.DeleteFolder(folder, c.Extend<IRequest>(Context));
        }

        public void CreateFolder(string folder, Callback c) {
            Provider.CreateFolder(folder, c.Extend<IRequest>(Context));
        }

        public void DeleteFile(string filename, Callback c) {
            Provider.DeleteFile(filename, c.Extend<IRequest>(Context));
        }

        public string GetKnownFolder(string knownFolder, Callback c) {
            return Provider.GetKnownFolder(knownFolder, c.Extend<IRequest>(Context));
        }

        public bool IsElevated(Callback c) {
            return Provider.IsElevated(c.Extend<IRequest>(Context));
        }
    }
}