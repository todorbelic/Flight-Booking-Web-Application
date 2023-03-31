﻿using System.Linq.Expressions;
using XMLApp.Model;

namespace XMLApp.Repository
{
    public interface IRepository<TDocument> where TDocument : IDocument
    {
        IQueryable<TDocument> AsQueryable();

        IEnumerable<TDocument> FilterBy(
            Expression<Func<TDocument, bool>> filterExpression);

        TDocument FindOne(Expression<Func<TDocument, bool>> filterExpression);

        Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression);

        TDocument FindById(string id);

        Task<TDocument> FindByIdAsync(string id);

        TDocument InsertOne(TDocument document);

        Task<TDocument> InsertOneAsync(TDocument document);

        void ReplaceOne(TDocument document);

        Task ReplaceOneAsync(TDocument document);

        void DeleteById(string id);

        Task DeleteByIdAsync(string id);
    }
}
