# Quickstart: MVP RSS Reader Validation

## Prerequisites

- .NET SDK installed for the current project target
- A local development environment capable of running ASP.NET Core and Blazor applications
- The backend and frontend projects initialized under the repository structure

## Validation Flow

1. Start the backend API.
2. Start the Blazor frontend.
3. Open the application in a browser.
4. On the subscriptions page, enter a valid-looking feed URL such as:
   `https://example.com/feed.xml`
5. Submit the form.
6. Confirm that the URL appears in the subscription list immediately.
7. Add a second URL.
8. Confirm the list updates and includes both entries in the expected order.

## Expected Outcomes

- The app loads without ambiguous routing or missing-page errors.
- The user can add subscriptions without any feed-fetching logic.
- The list updates in place after each successful add.
- The page remains a simple, focused demonstration of subscription management.

## Success Criteria for Validation

The MVP is considered working when the user can complete the add-and-display flow without any additional configuration or feed parsing.
