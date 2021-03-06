﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MngrPaycheck.Administrator.ProductParameterValueServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProductParameterValueServiceReference.IProductParameterValueRepositoryService")]
    public interface IProductParameterValueRepositoryService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductParameterValueRepositoryService/GetAll", ReplyAction="http://tempuri.org/IProductParameterValueRepositoryService/GetAllResponse")]
        string GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductParameterValueRepositoryService/GetAll", ReplyAction="http://tempuri.org/IProductParameterValueRepositoryService/GetAllResponse")]
        System.Threading.Tasks.Task<string> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductParameterValueRepositoryService/Add", ReplyAction="http://tempuri.org/IProductParameterValueRepositoryService/AddResponse")]
        void Add(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductParameterValueRepositoryService/Add", ReplyAction="http://tempuri.org/IProductParameterValueRepositoryService/AddResponse")]
        System.Threading.Tasks.Task AddAsync(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductParameterValueRepositoryService/Delete", ReplyAction="http://tempuri.org/IProductParameterValueRepositoryService/DeleteResponse")]
        void Delete(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductParameterValueRepositoryService/Delete", ReplyAction="http://tempuri.org/IProductParameterValueRepositoryService/DeleteResponse")]
        System.Threading.Tasks.Task DeleteAsync(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductParameterValueRepositoryService/Update", ReplyAction="http://tempuri.org/IProductParameterValueRepositoryService/UpdateResponse")]
        void Update(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductParameterValueRepositoryService/Update", ReplyAction="http://tempuri.org/IProductParameterValueRepositoryService/UpdateResponse")]
        System.Threading.Tasks.Task UpdateAsync(string json);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IProductParameterValueRepositoryServiceChannel : MngrPaycheck.Administrator.ProductParameterValueServiceReference.IProductParameterValueRepositoryService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProductParameterValueRepositoryServiceClient : System.ServiceModel.ClientBase<MngrPaycheck.Administrator.ProductParameterValueServiceReference.IProductParameterValueRepositoryService>, MngrPaycheck.Administrator.ProductParameterValueServiceReference.IProductParameterValueRepositoryService {
        
        public ProductParameterValueRepositoryServiceClient() {
        }
        
        public ProductParameterValueRepositoryServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ProductParameterValueRepositoryServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductParameterValueRepositoryServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductParameterValueRepositoryServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<string> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public void Add(string json) {
            base.Channel.Add(json);
        }
        
        public System.Threading.Tasks.Task AddAsync(string json) {
            return base.Channel.AddAsync(json);
        }
        
        public void Delete(string json) {
            base.Channel.Delete(json);
        }
        
        public System.Threading.Tasks.Task DeleteAsync(string json) {
            return base.Channel.DeleteAsync(json);
        }
        
        public void Update(string json) {
            base.Channel.Update(json);
        }
        
        public System.Threading.Tasks.Task UpdateAsync(string json) {
            return base.Channel.UpdateAsync(json);
        }
    }
}
