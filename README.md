# HomeSalesAPI
Code for HomeSales API

1) I have covered positive test cases for both the API methods.
2) In Order to make performance better, we can call the methods aynchronously using Task, async and await.
    For ex: **public async Task<List<HomeSales>** ReadCSVFiles()
    {}
     while calling above method we can use, **await** ReadCSVFiles();
 3) I have handled the exception by throwing the error message to the screen when exception occurs. 
