using System;

namespace Core
{
    public abstract class BaseEntity
    {
        public DateTime DateInsert { get; private set; }
        public DateTime DateModified { get; private set; }
        public bool IsDeleted { get; private set; }

        public void Delete() => this.IsDeleted = true;

        public void UndoDelete() => this.IsDeleted = false;

        public void SetModificationDate() => this.DateModified = DateTime.Now;

        public void SetInsertDate()
        {
            if (this.DateInsert == default)
                this.DateInsert = DateTime.Now;
            else
                throw new Exception("Insert Data cannot be modified");
        }
    }
}