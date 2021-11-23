using Firebase.Database;

namespace Storage.DataAccessLayer
{
    public  class DbContext
    {
        public readonly FirebaseClient firebaseClient = new("https://quizonline-ed972-default-rtdb.firebaseio.com/");
    }
}
