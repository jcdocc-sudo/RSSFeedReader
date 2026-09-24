# Subscriptions API Contract

## Overview

The MVP exposes a minimal API for storing and retrieving the current list of feed subscriptions. This contract is intentionally small and matches the project’s subscription-management scope.

## Base Path

`/api/subscriptions`

## Endpoints

### GET /api/subscriptions

Returns the current list of subscriptions.

**Response**:

```json
[
  {
    "id": "1",
    "url": "https://example.com/feed.xml",
    "addedAt": "2026-09-24T12:00:00Z"
  }
]
```

### POST /api/subscriptions

Adds a new subscription to the in-memory list.

**Request body**:

```json
{
  "url": "https://example.com/feed.xml"
}
```

**Response**:
- HTTP 200 or HTTP 201 on success
- Returns the created subscription payload or the updated list

**Validation behavior for MVP**:
- A non-empty URL is accepted as-is
- No feed validation is required
- No persistence is required beyond the current runtime session

## Notes

This contract is intentionally narrow and provides only the data needed for the subscription-list experience in the MVP. Feed fetching, parse results, and item display are deferred to later phases.
