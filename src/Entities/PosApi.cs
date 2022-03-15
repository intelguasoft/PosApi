﻿// <auto-generated>
// ReSharper disable All

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Entities
{
    #region Database context interface

    public interface IRepositoryContext : IDisposable
    {
        DbSet<Company_Company> Company_Companies { get; set; } // Company
        DbSet<Employee_Employee> Employee_Employees { get; set; } // Employee

        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken));
        DatabaseFacade Database { get; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        string ToString();

        EntityEntry Add(object entity);
        EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class;
        Task AddRangeAsync(params object[] entities);
        Task AddRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken = default);
        ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class;
        ValueTask<EntityEntry> AddAsync(object entity, CancellationToken cancellationToken = default);
        void AddRange(IEnumerable<object> entities);
        void AddRange(params object[] entities);

        EntityEntry Attach(object entity);
        EntityEntry<TEntity> Attach<TEntity>(TEntity entity) where TEntity : class;
        void AttachRange(IEnumerable<object> entities);
        void AttachRange(params object[] entities);

        EntityEntry Entry(object entity);
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        TEntity Find<TEntity>(params object[] keyValues) where TEntity : class;
        ValueTask<TEntity> FindAsync<TEntity>(object[] keyValues, CancellationToken cancellationToken) where TEntity : class;
        ValueTask<TEntity> FindAsync<TEntity>(params object[] keyValues) where TEntity : class;
        ValueTask<object> FindAsync(Type entityType, object[] keyValues, CancellationToken cancellationToken);
        ValueTask<object> FindAsync(Type entityType, params object[] keyValues);
        object Find(Type entityType, params object[] keyValues);

        EntityEntry Remove(object entity);
        EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class;
        void RemoveRange(IEnumerable<object> entities);
        void RemoveRange(params object[] entities);

        EntityEntry Update(object entity);
        EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;
        void UpdateRange(IEnumerable<object> entities);
        void UpdateRange(params object[] entities);

        IQueryable<TResult> FromExpression<TResult>(Expression<Func<IQueryable<TResult>>> expression);
    }

    #endregion

    #region Database context

    public class RepositoryContext : DbContext, IRepositoryContext
    {
        public RepositoryContext()
        {
        }

        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
        }

        public DbSet<Company_Company> Company_Companies { get; set; } // Company
        public DbSet<Employee_Employee> Employee_Employees { get; set; } // Employee

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(local);Initial Catalog=PosApi;Integrated Security=True;MultipleActiveResultSets=True");
            }
        }

        public static bool IsSqlParameterNull(SqlParameter param)
        {
            var sqlValue = param.SqlValue;
            var nullableValue = sqlValue as INullable;
            if (nullableValue != null)
                return nullableValue.IsNull;
            return (sqlValue == null || sqlValue == DBNull.Value);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new Company_CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new Employee_EmployeeConfiguration());
        }

    }

    #endregion

    #region Database context factory

    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            return new RepositoryContext();
        }
    }

    #endregion

    #region Fake Database context

    public class FakeRepositoryContext : IRepositoryContext
    {
        public DbSet<Company_Company> Company_Companies { get; set; } // Company
        public DbSet<Employee_Employee> Employee_Employees { get; set; } // Employee

        public FakeRepositoryContext()
        {
            _database = new FakeDatabaseFacade(new RepositoryContext());

            Company_Companies = new FakeDbSet<Company_Company>("CompanyId");
            Employee_Employees = new FakeDbSet<Employee_Employee>("EmployeeId");

        }

        public int SaveChangesCount { get; private set; }
        public virtual int SaveChanges()
        {
            ++SaveChangesCount;
            return 1;
        }

        public virtual int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return SaveChanges();
        }

        public virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            ++SaveChangesCount;
            return Task<int>.Factory.StartNew(() => 1, cancellationToken);
        }
        public virtual Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken)
        {
            ++SaveChangesCount;
            return Task<int>.Factory.StartNew(x => 1, acceptAllChangesOnSuccess, cancellationToken);
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private DatabaseFacade _database;
        public DatabaseFacade Database { get { return _database; } }

        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public virtual EntityEntry Add(object entity)
        {
            throw new NotImplementedException();
        }

        public virtual EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public virtual Task AddRangeAsync(params object[] entities)
        {
            throw new NotImplementedException();
        }

        public virtual async Task AddRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual async ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual async ValueTask<EntityEntry> AddAsync(object entity, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual void AddRange(IEnumerable<object> entities)
        {
            throw new NotImplementedException();
        }

        public virtual void AddRange(params object[] entities)
        {
            throw new NotImplementedException();
        }

        public virtual EntityEntry Attach(object entity)
        {
            throw new NotImplementedException();
        }

        public virtual EntityEntry<TEntity> Attach<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public virtual void AttachRange(IEnumerable<object> entities)
        {
            throw new NotImplementedException();
        }

        public virtual void AttachRange(params object[] entities)
        {
            throw new NotImplementedException();
        }

        public virtual EntityEntry Entry(object entity)
        {
            throw new NotImplementedException();
        }

        public virtual EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public virtual TEntity Find<TEntity>(params object[] keyValues) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public virtual ValueTask<TEntity> FindAsync<TEntity>(object[] keyValues, CancellationToken cancellationToken) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public virtual ValueTask<TEntity> FindAsync<TEntity>(params object[] keyValues) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public virtual ValueTask<object> FindAsync(Type entityType, object[] keyValues, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual ValueTask<object> FindAsync(Type entityType, params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public virtual object Find(Type entityType, params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public virtual EntityEntry Remove(object entity)
        {
            throw new NotImplementedException();
        }

        public virtual EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public virtual void RemoveRange(IEnumerable<object> entities)
        {
            throw new NotImplementedException();
        }

        public virtual void RemoveRange(params object[] entities)
        {
            throw new NotImplementedException();
        }

        public virtual EntityEntry Update(object entity)
        {
            throw new NotImplementedException();
        }

        public virtual EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public virtual void UpdateRange(IEnumerable<object> entities)
        {
            throw new NotImplementedException();
        }

        public virtual void UpdateRange(params object[] entities)
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<TResult> FromExpression<TResult>(Expression<Func<IQueryable<TResult>>> expression)
        {
            throw new NotImplementedException();
        }

    }

    #endregion

    #region Fake DbSet

    // ************************************************************************
    // Fake DbSet
    // Implementing Find:
    //      The Find method is difficult to implement in a generic fashion. If
    //      you need to test code that makes use of the Find method it is
    //      easiest to create a test DbSet for each of the entity types that
    //      need to support find. You can then write logic to find that
    //      particular type of entity, as shown below:
    //      public class FakeBlogDbSet : FakeDbSet<Blog>
    //      {
    //          public override Blog Find(params object[] keyValues)
    //          {
    //              var id = (int) keyValues.Single();
    //              return this.SingleOrDefault(b => b.BlogId == id);
    //          }
    //      }
    //      Read more about it here: https://msdn.microsoft.com/en-us/data/dn314431.aspx
    public class FakeDbSet<TEntity> :
        DbSet<TEntity>,
        IQueryable<TEntity>,
        IAsyncEnumerable<TEntity>,
        IListSource,
        IResettableService
        where TEntity : class
    {
        private readonly PropertyInfo[] _primaryKeys;
        private ObservableCollection<TEntity> _data;
        private IQueryable _query;
        public override IEntityType EntityType { get; }

        public FakeDbSet()
        {
            _primaryKeys = null;
            _data = new ObservableCollection<TEntity>();
            _query = _data.AsQueryable();
        }

        public FakeDbSet(params string[] primaryKeys)
        {
            _primaryKeys = typeof(TEntity).GetProperties().Where(x => primaryKeys.Contains(x.Name)).ToArray();
            _data = new ObservableCollection<TEntity>();
            _query = _data.AsQueryable();
        }

        public override TEntity Find(params object[] keyValues)
        {
            if (_primaryKeys == null)
                throw new ArgumentException("No primary keys defined");
            if (keyValues.Length != _primaryKeys.Length)
                throw new ArgumentException("Incorrect number of keys passed to Find method");

            var keyQuery = this.AsQueryable();
            keyQuery = keyValues
                .Select((t, i) => i)
                .Aggregate(keyQuery,
                    (current, x) =>
                        current.Where(entity => _primaryKeys[x].GetValue(entity, null).Equals(keyValues[x])));

            return keyQuery.SingleOrDefault();
        }

        public override ValueTask<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken)
        {
            return new ValueTask<TEntity>(Task<TEntity>.Factory.StartNew(() => Find(keyValues), cancellationToken));
        }

        public override ValueTask<TEntity> FindAsync(params object[] keyValues)
        {
            return new ValueTask<TEntity>(Task<TEntity>.Factory.StartNew(() => Find(keyValues)));
        }

        public override EntityEntry<TEntity> Add(TEntity entity)
        {
            _data.Add(entity);
            return null;
        }

        public override ValueTask<EntityEntry<TEntity>> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return new ValueTask<EntityEntry<TEntity>>(Task<EntityEntry<TEntity>>.Factory.StartNew(() => Add(entity)));
        }

        public override void AddRange(params TEntity[] entities)
        {
            if (entities == null) throw new ArgumentNullException("entities");
            foreach (var entity in entities)
                _data.Add(entity);
        }

        public override void AddRange(IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException("entities");
            foreach (var entity in entities)
                _data.Add(entity);
        }

        public override Task AddRangeAsync(params TEntity[] entities)
        {
            if (entities == null) throw new ArgumentNullException("entities");
            return Task.Factory.StartNew(() => AddRange(entities));
        }

        public override Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            if (entities == null) throw new ArgumentNullException("entities");
            return Task.Factory.StartNew(() => AddRange(entities));
        }

        public override EntityEntry<TEntity> Attach(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            return Add(entity);
        }

        public override void AttachRange(params TEntity[] entities)
        {
            if (entities == null) throw new ArgumentNullException("entities");
            AddRange(entities);
        }

        public override void AttachRange(IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException("entities");
            AddRange(entities);
        }

        public override EntityEntry<TEntity> Remove(TEntity entity)
        {
            _data.Remove(entity);
            return null;
        }

        public override void RemoveRange(params TEntity[] entities)
        {
            if (entities == null) throw new ArgumentNullException("entities");
            foreach (var entity in entities.ToList())
                _data.Remove(entity);
        }

        public override void RemoveRange(IEnumerable<TEntity> entities)
        {
            RemoveRange(entities.ToArray());
        }

        public override EntityEntry<TEntity> Update(TEntity entity)
        {
            _data.Remove(entity);
            _data.Add(entity);
            return null;
        }

        public override void UpdateRange(params TEntity[] entities)
        {
            if (entities == null) throw new ArgumentNullException("entities");
            RemoveRange(entities);
            AddRange(entities);
        }

        public override void UpdateRange(IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException("entities");
            var array = entities.ToArray(); RemoveRange(array);
            AddRange(array);
        }

        bool IListSource.ContainsListCollection => true;

        public IList GetList()
        {
            return _data;
        }

        IList IListSource.GetList()
        {
            return _data;
        }

        Type IQueryable.ElementType
        {
            get { return _query.ElementType; }
        }

        Expression IQueryable.Expression
        {
            get { return _query.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return new FakeDbAsyncQueryProvider<TEntity>(_data); }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        public override IAsyncEnumerator<TEntity> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return new FakeDbAsyncEnumerator<TEntity>(this.AsEnumerable().GetEnumerator());
        }

        public void ResetState()
        {
            _data = new ObservableCollection<TEntity>();
            _query = _data.AsQueryable();
        }

        public Task ResetStateAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.Factory.StartNew(() => ResetState());
        }
    }

    public class FakeDbAsyncQueryProvider<TEntity> : FakeQueryProvider<TEntity>, IAsyncEnumerable<TEntity>, IAsyncQueryProvider
    {
        public FakeDbAsyncQueryProvider(Expression expression) : base(expression)
        {
        }

        public FakeDbAsyncQueryProvider(IEnumerable<TEntity> enumerable) : base(enumerable)
        {
        }

        public TResult ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
        {
            var expectedResultType = typeof(TResult).GetGenericArguments()[0];
            var executionResult = typeof(IQueryProvider)
                .GetMethods()
                .First(method => method.Name == nameof(IQueryProvider.Execute) && method.IsGenericMethod)
                .MakeGenericMethod(expectedResultType)
                .Invoke(this, new object[] { expression });

            return (TResult)typeof(Task).GetMethod(nameof(Task.FromResult))
                ?.MakeGenericMethod(expectedResultType)
                .Invoke(null, new[] { executionResult });
        }

        public IAsyncEnumerator<TEntity> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return new FakeDbAsyncEnumerator<TEntity>(this.AsEnumerable().GetEnumerator());
        }
    }

    public class FakeDbAsyncEnumerable<T> : EnumerableQuery<T>, IAsyncEnumerable<T>, IQueryable<T>
    {
        public FakeDbAsyncEnumerable(IEnumerable<T> enumerable)
            : base(enumerable)
        {
        }

        public FakeDbAsyncEnumerable(Expression expression)
            : base(expression)
        {
        }

        IAsyncEnumerator<T> IAsyncEnumerable<T>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAsyncEnumerator(cancellationToken);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.AsEnumerable().GetEnumerator();
        }

        public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = new CancellationToken())
        {
            return new FakeDbAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
        }
    }

    public class FakeDbAsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> _inner;

        public FakeDbAsyncEnumerator(IEnumerator<T> inner)
        {
            _inner = inner;
        }

        public ValueTask DisposeAsync()
        {
            _inner.Dispose();
            return new ValueTask(Task.CompletedTask);
        }

        public ValueTask<bool> MoveNextAsync()
        {
            return new ValueTask<bool>(_inner.MoveNext());
        }

        public T Current
        {
            get { return _inner.Current; }
        }
    }

    public abstract class FakeQueryProvider<T> : IOrderedQueryable<T>, IQueryProvider
    {
        private IEnumerable<T> _enumerable;

        protected FakeQueryProvider(Expression expression)
        {
            Expression = expression;
        }

        protected FakeQueryProvider(IEnumerable<T> enumerable)
        {
            _enumerable = enumerable;
            Expression = enumerable.AsQueryable().Expression;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            if (_enumerable == null) _enumerable = CompileExpressionItem<IEnumerable<T>>(Expression);
            return _enumerable.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            if (_enumerable == null) _enumerable = CompileExpressionItem<IEnumerable<T>>(Expression);
            return _enumerable.GetEnumerator();
        }

        private static TResult CompileExpressionItem<TResult>(Expression expression)
        {
            var visitor = new FakeExpressionVisitor();
            var body = visitor.Visit(expression);
            var f = Expression.Lambda<Func<TResult>>(body ?? throw new InvalidOperationException($"{nameof(body)} is null"), (IEnumerable<ParameterExpression>)null);
            return f.Compile()();
        }

        private object CreateInstance(Type tElement, Expression expression)
        {
            var queryType = GetType().GetGenericTypeDefinition().MakeGenericType(tElement);
            return Activator.CreateInstance(queryType, expression);
        }

        public IQueryable CreateQuery(Expression expression)
        {
            if (expression is MethodCallExpression m)
            {
                var resultType = m.Method.ReturnType; // it should be IQueryable<T>
                var tElement = resultType.GetGenericArguments().First();
                return (IQueryable)CreateInstance(tElement, expression);
            }

            return CreateQuery<T>(expression);
        }

        public IQueryable<TEntity> CreateQuery<TEntity>(Expression expression)
        {
            return (IQueryable<TEntity>)CreateInstance(typeof(TEntity), expression);
        }

        public object Execute(Expression expression)
        {
            return CompileExpressionItem<object>(expression);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return CompileExpressionItem<TResult>(expression);
        }

        public Type ElementType => typeof(T);

        public Expression Expression { get; }

        public IQueryProvider Provider => this;
    }

    public class FakeExpressionVisitor : ExpressionVisitor
    {
    }

    public class FakeDatabaseFacade : DatabaseFacade
    {
        public FakeDatabaseFacade(DbContext context) : base(context)
        {
        }

        public override IDbContextTransaction BeginTransaction()
        {
            return new FakeDbContextTransaction();
        }

        public override Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(BeginTransaction());
        }

        public override bool CanConnect()
        {
            return true;
        }

        public override Task<bool> CanConnectAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(CanConnect());
        }

        public override void CommitTransaction()
        {
        }

        public override Task CommitTransactionAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.CompletedTask;
        }

        public override IExecutionStrategy CreateExecutionStrategy()
        {
            return null;
        }

        public override bool EnsureCreated()
        {
            return true;
        }

        public override Task<bool> EnsureCreatedAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(EnsureCreated());
        }

        public override bool EnsureDeleted()
        {
            return true;
        }

        public override Task<bool> EnsureDeletedAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(EnsureDeleted());
        }

        public override void RollbackTransaction()
        {
        }

        public override Task RollbackTransactionAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.CompletedTask;
        }

        public override string ToString()
        {
            return string.Empty;
        }
    }

    public class FakeDbContextTransaction : IDbContextTransaction
    {
        public void Commit() { }
        public Task CommitAsync(CancellationToken cancellationToken = new CancellationToken()) => Task.CompletedTask;
        public void Dispose() { }
        public ValueTask DisposeAsync() => default;
        public void Rollback() { }
        public Task RollbackAsync(CancellationToken cancellationToken = new CancellationToken()) => Task.CompletedTask;

        public Guid TransactionId => Guid.NewGuid();
    }

    #endregion

    #region POCO classes

    // Company
    public class Company_Company
    {
        public int CompanyId { get; set; } // CompanyId (Primary key)
        public string Name { get; set; } // Name (length: 40)
        public string Address { get; set; } // Address (length: 60)
        public string City { get; set; } // City (length: 20)
        public string State { get; set; } // State (length: 20)
        public string ZipCode { get; set; } // ZipCode (length: 10)
        public string Country { get; set; } // Country (length: 20)
        public string Phone { get; set; } // Phone (length: 15)
        public bool IsDeleted { get; set; } // IsDeleted
        public string CreatedByApiKey { get; set; } // CreatedByApiKey (length: 100)
        public DateTime CreatedDate { get; set; } // CreatedDate
        public string LastModifiedApiKey { get; set; } // LastModifiedApiKey (length: 100)
        public DateTime? LastModifiedDate { get; set; } // LastModifiedDate

        // Reverse navigation

        /// <summary>
        /// Child Employee_Employees where [Employee].[CompanyId] point to this entity (FK_Employee_Company)
        /// </summary>
        public virtual ICollection<Employee_Employee> Employee_Employees { get; set; } // Employee.FK_Employee_Company

        public Company_Company()
        {
            IsDeleted = false;
            Employee_Employees = new List<Employee_Employee>();
        }
    }

    // Employee
    public class Employee_Employee
    {

        public Employee_Employee()
        {
            IsDeleted = false;
        }

        public int Age { get; set; } // Age

        // Foreign keys

        /// <summary>
        /// Parent Company_Company pointed by [Employee].([CompanyId]) (FK_Employee_Company)
        /// </summary>
        public virtual Company_Company Company_Company { get; set; } // FK_Employee_Company
        public int CompanyId { get; set; } // CompanyId
        public string CreatedApiKey { get; set; } // CreatedApiKey (length: 100)
        public DateTime CreatedDate { get; set; } // CreatedDate
        public int EmployeeId { get; set; } // EmployeeId (Primary key)
        public string FirstName { get; set; } // FirstName (length: 15)
        public bool IsDeleted { get; set; } // IsDeleted
        public string LastModifiedApiKey { get; set; } // LastModifiedApiKey (length: 100)
        public DateTime? LastModifiedDate { get; set; } // LastModifiedDate
        public string LastName { get; set; } // LastName (length: 15)
        public string MiddleName { get; set; } // MiddleName (length: 15)
        public string Phone { get; set; } // Phone (length: 15)
        public string Position { get; set; } // Position (length: 20)
    }


    #endregion

    #region POCO Configuration

    // Company
    public class Company_CompanyConfiguration : IEntityTypeConfiguration<Company_Company>
    {
        public void Configure(EntityTypeBuilder<Company_Company> builder)
        {
            builder.ToTable("Company", "Company");
            builder.HasKey(x => x.CompanyId).HasName("PK_Company").IsClustered();

            builder.Property(x => x.CompanyId).HasColumnName(@"CompanyId").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar(40)").IsRequired().HasMaxLength(40);
            builder.Property(x => x.Address).HasColumnName(@"Address").HasColumnType("nvarchar(60)").IsRequired().HasMaxLength(60);
            builder.Property(x => x.City).HasColumnName(@"City").HasColumnType("nvarchar(20)").IsRequired().HasMaxLength(20);
            builder.Property(x => x.State).HasColumnName(@"State").HasColumnType("nvarchar(20)").IsRequired().HasMaxLength(20);
            builder.Property(x => x.ZipCode).HasColumnName(@"ZipCode").HasColumnType("nvarchar(10)").IsRequired().HasMaxLength(10);
            builder.Property(x => x.Country).HasColumnName(@"Country").HasColumnType("nvarchar(20)").IsRequired().HasMaxLength(20);
            builder.Property(x => x.Phone).HasColumnName(@"Phone").HasColumnType("nvarchar(15)").IsRequired().HasMaxLength(15);
            builder.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();
            builder.Property(x => x.CreatedByApiKey).HasColumnName(@"CreatedByApiKey").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.CreatedDate).HasColumnName(@"CreatedDate").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.LastModifiedApiKey).HasColumnName(@"LastModifiedApiKey").HasColumnType("nvarchar(100)").IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.LastModifiedDate).HasColumnName(@"LastModifiedDate").HasColumnType("datetime").IsRequired(false);

            builder.HasIndex(x => x.Name).HasDatabaseName("IX_Companies_Name").IsUnique();
        }
    }

    // Employee
    public class Employee_EmployeeConfiguration : IEntityTypeConfiguration<Employee_Employee>
    {
        public void Configure(EntityTypeBuilder<Employee_Employee> builder)
        {
            builder.ToTable("Employee", "Employee");
            builder.HasKey(x => x.EmployeeId).HasName("PK_Employee").IsClustered();

            builder.Property(x => x.EmployeeId).HasColumnName(@"EmployeeId").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.CompanyId).HasColumnName(@"CompanyId").HasColumnType("int").IsRequired();
            builder.Property(x => x.FirstName).HasColumnName(@"FirstName").HasColumnType("nvarchar(15)").IsRequired().HasMaxLength(15);
            builder.Property(x => x.MiddleName).HasColumnName(@"MiddleName").HasColumnType("nvarchar(15)").IsRequired().HasMaxLength(15);
            builder.Property(x => x.LastName).HasColumnName(@"LastName").HasColumnType("nvarchar(15)").IsRequired().HasMaxLength(15);
            builder.Property(x => x.Age).HasColumnName(@"Age").HasColumnType("int").IsRequired();
            builder.Property(x => x.Position).HasColumnName(@"Position").HasColumnType("nvarchar(20)").IsRequired().HasMaxLength(20);
            builder.Property(x => x.Phone).HasColumnName(@"Phone").HasColumnType("nvarchar(15)").IsRequired().HasMaxLength(15);
            builder.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();
            builder.Property(x => x.CreatedApiKey).HasColumnName(@"CreatedApiKey").HasColumnType("nvarchar(100)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.CreatedDate).HasColumnName(@"CreatedDate").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.LastModifiedApiKey).HasColumnName(@"LastModifiedApiKey").HasColumnType("nvarchar(100)").IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.LastModifiedDate).HasColumnName(@"LastModifiedDate").HasColumnType("datetime").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.Company_Company).WithMany(b => b.Employee_Employees).HasForeignKey(c => c.CompanyId).HasConstraintName("FK_Employee_Company");

            builder.HasIndex(x => x.CompanyId).HasDatabaseName("IX_Employees_CompanyId");
            builder.HasIndex(x => new { x.FirstName, x.MiddleName, x.LastName }).HasDatabaseName("IX_Employees_FirstName_MiddleName_LastName").IsUnique();
        }
    }


    #endregion

}
// </auto-generated>
