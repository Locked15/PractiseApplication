# PractiseApplication

This in my practise application.
Request-Based Controlling System.

## Start Up

Firstly, remember about database: backups lies inside 'resources' directory.
You can restore it via any supported tools (like 'pgAdmin' or 'PostgreSQL Shell').

Then, you need to configure your connection string.
I don't moved it to configuration file, so you can change it directly in source code.

## Functionality

After log-in, you need will moved to main window.
There you can complete some actions by interact with corresponding elements.

By double click on request, you will move to configure page.
If your role is 'Administrator' or 'Master', you can work with requests.
Otherwise, you can't.
