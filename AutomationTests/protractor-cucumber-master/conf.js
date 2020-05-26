exports.config = {

    // setting to launch tests directly without selenium server
    directConnect: true,
    // address of running selenium server
    seleniumAddress: 'http://localhost:4444/wd/hub',

    // setting time outs
    getPageTimeOut: 200000,
    allScriptsTimeout: 500000,

    // setting framework
    framework: 'custom',
    // path relative to the current config file
    frameworkPath: require.resolve('protractor-cucumber-framework'),

    // setting protractor to ignore uncaught exceptions to take care by protractor-cucumber-framework
    ignoreUncaughtExceptions: true,

    // configuration parameters
    params: {
        testEnv: 'test'
    },

    // browser to launch tests
    capabilities: {
        browserName: 'chrome',
        chromeOptions: {
            args: ['--disable-extensions', '--safe-mode']
        }
    },

    // Specify Test Files
    //
    // Define which tests should execute
    specs: [
        'features/login.feature',
        // 'features/signup.feature'
    ],

    //Define which tests should be excluded from execution.
    exclude: [
        // 'features/search.feature'
    ],

    // arguments to cucumber.js
    cucumberOpts: {
        require: [
             'features/support/env.js',
             'features/support/hooks.js',
            'features/step_definitions/searchSteps.js',
            'features/step_definitions/loginSteps.js',
            // 'features/step_definitions/signUpSteps.js'
        ],
        tags: false,
        
        // format: ['progress', 'pretty:output.txt'],
        // format: 'pretty',
        profile: false,
        'no-source': true
    }
};
