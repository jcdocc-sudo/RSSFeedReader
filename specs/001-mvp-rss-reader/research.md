# Research: MVP RSS Reader

## Decision: Use ASP.NET Core Web API + Blazor WebAssembly

**Decision**: Build the MVP with ASP.NET Core Web API for the backend and Blazor WebAssembly for the frontend.

**Rationale**: This matches the project’s stated technical baseline and gives a clean separation between user interaction and subscription management. It also keeps the architecture ready for later feed-fetching and persistence work without requiring a rewrite.

**Alternatives considered**:
- Single-page application only: Rejected because the project explicitly selects a backend + frontend split.
- Full production architecture from day one: Rejected because it would add unnecessary complexity before the MVP is proven.

## Decision: Keep subscription storage in memory

**Decision**: Store subscriptions as an in-memory collection during the active session.

**Rationale**: The MVP is explicitly defined as a proof of concept focused on adding subscriptions and seeing them appear in the UI. Memory storage is the simplest option that supports the required behavior without introducing persistence complexity.

**Alternatives considered**:
- Database persistence: Deferred to later phases because it is beyond the MVP scope.
- Local file storage: Rejected because it adds platform and persistence complexity without user value for the initial requirement.

## Decision: Accept feed URLs without validation in the MVP

**Decision**: Treat any non-empty user-entered URL as a valid subscription input for the MVP.

**Rationale**: The stakeholder goals explicitly state that URL validation is intentionally skipped to keep the MVP simple and fast to develop.

**Alternatives considered**:
- URL validation and error messages: Rejected because the current scope does not require network or feed validation.
- Feed parsing during add: Rejected because feed fetching and parsing are deferred to Extended-MVP.

## Decision: Keep the UI to a single subscription workflow

**Decision**: Provide one page with an input box and a subscription list.

**Rationale**: This directly matches the user need and limits the interface to the core workflow: add a feed URL and review the resulting list.

**Alternatives considered**:
- Multi-page navigation: Not needed for the MVP.
- Rich feed item display: Deferred to Extended-MVP because it is outside the immediate feature requirement.

## Decision: Defer feed fetching and item display

**Decision**: Keep the app focused on subscription creation and list display only.

**Rationale**: The stakeholder definition of “MVP working” allows the app to display subscriptions without fetching or displaying feed content.

**Alternatives considered**:
- Manual refresh and item display: Good next step after the subscription management workflow is working, but not required for this milestone.
- Automatic polling: Explicitly out of scope for the MVP and future phases.

## Final Conclusion

The chosen design stays tightly aligned with the project goals, minimizes unnecessary engineering, and leaves a clean path for future enhancements such as real feed fetching, persistence, and richer item display.
