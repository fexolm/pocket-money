namespace PocketMoney.Data
module DbContext = 
    let private provider = Firebase.DataAccessProvider()

    let Open (f : IDataAccessProvicer -> 'a) = 
        f provider


