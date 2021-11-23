using Firebase.Database;

namespace DataStorage.DataAccessLayer
{
    public  class DbContext
    {
        public readonly FirebaseClient firebaseClient = new FirebaseClient("https://quizonline-ed972-default-rtdb.firebaseio.com/");
    }
}
