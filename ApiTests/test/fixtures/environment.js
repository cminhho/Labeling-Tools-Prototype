(function(){
    host.global.API_ROOT = getEnvironmentVariable('API_ROOT', 'https://localhost:44342/api');

    // Generate a unique API Key by default
    host.global.API_KEY = getEnvironmentVariable('API_KEY', Date.now().toString());
}());