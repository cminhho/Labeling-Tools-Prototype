// Before And After hooks used while feature executes

var outputDir = './reports/';
var screenshotDir = './reports/screenshots/';
var targetJson = outputDir + 'cucumber_report.json';
var {setDefaultTimeout} = require('cucumber');
var JsonFormatter = require('cucumber').JsonFormatter;
var fse = require('fs-extra');
var reporter = require('cucumber-html-reporter');

const {AfterAll, After, Before} = require('cucumber');
Before({timeout: 60 * 1000}, function() {
    // Does some slow browser/filesystem/network actions
  });
Before({
    timeout: 2 * 1000
  }, async (scenario) => {
    var configData = require('../../data/config.json');
        console.log("Launching test in environment: ", browser.params.testEnv);
        config = configData[browser.params.testEnv];
  });

    Before(function () {
        console.log("Before All hook====")
    });

    Before("@dev", function () {
        console.log("Execution started for Scenarios tag as @dev")
    });

    Before("@stag", function () {
        console.log("Execution started for Scenarios tag as @stag")
    });


    var {setDefaultTimeout} = require('cucumber');
setDefaultTimeout(60 * 1000);


    After("@dev", function () {
        console.log("Execution done for Scenarios tag as @dev")
    });

    After("@stag", function () {
        console.log("Execution done for Scenarios tag as @stag")
    });

    After(function () {
        console.log("After All hook====")
    });


    
