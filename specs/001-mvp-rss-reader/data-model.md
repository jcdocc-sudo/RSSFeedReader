# Data Model: MVP RSS Reader

## Overview

The MVP models a minimal feed-reading workflow built around a single user-managed list of subscriptions. The core entity is a subscription record, which persists only for the lifetime of the active session.

## Entities

### Subscription

Represents a single RSS or Atom feed the user wants to track.

**Fields**:
- Id: unique identifier for the subscription record
- Url: the feed URL supplied by the user
- AddedAt: timestamp when the subscription was created

**Relationships**:
- A subscription belongs to a single user session
- A session contains a collection of subscriptions

**Validation rules**:
- Url must be present and non-empty
- The system accepts the URL as provided without deeper validation in the MVP
- The active list reflects all currently added subscriptions

### SubscriptionList

Represents the collection of subscriptions currently displayed in the UI.

**Fields**:
- Items: ordered collection of Subscription records

**Relationships**:
- Each list contains zero or more Subscription items
- The list is displayed to and managed by the active user

**Validation rules**:
- The list is in-memory only for the current session
- Updates occur immediately after a new subscription is added

## State Model

### Session state

- Initial state: empty list
- User action: enter a URL and submit
- Result: the URL is added to the list and displayed in the UI

### Edge-case handling for MVP

- Empty input: ignored or treated as a no-op
- Duplicate URL: retained as a separate list entry unless future design explicitly defines de-duplication
- Session restart: list resets because persistence is out of scope

## Design Notes

This model keeps the MVP intentionally light and supports future enhancements such as persistence, removal, and feed-item display without requiring a redesign of the core data structure.
