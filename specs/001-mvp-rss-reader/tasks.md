# Tasks: MVP RSS Reader

**Input**: Design documents from [spec.md](spec.md), [plan.md](plan.md), [research.md](research.md), [data-model.md](data-model.md), and [contracts/subscriptions-api.md](contracts/subscriptions-api.md)

**Prerequisites**: plan.md (required), spec.md (required for user stories), research.md, data-model.md, contracts/

**Organization**: Tasks are grouped by the primary user story to keep the MVP increment independent and easy to validate.

## Phase 1: Setup (Shared Infrastructure)

**Purpose**: Create the baseline project structure and configuration for the backend and frontend.

- [ ] T001 Create the solution and project folders for the backend and frontend in `backend/` and `frontend/`
- [ ] T002 Initialize the ASP.NET Core Web API project under `backend/RSSFeedReader.Api/`
- [ ] T003 Initialize the Blazor WebAssembly project under `frontend/RSSFeedReader.UI/`
- [ ] T004 [P] Configure shared solution-level settings and keep the API base URL and startup ports aligned with the project design

---

## Phase 2: Foundational (Blocking Prerequisites)

**Purpose**: Establish the core app structure before implementing the subscription flow.

**Critical checkpoint**: No user story work begins until the backend/frontend bootstrapping and route cleanup are complete.

- [ ] T005 [P] Remove default template demo pages and routing conflicts from the Blazor app so the root page is the subscription page only
- [ ] T006 [P] Update the frontend navigation to remove template-only links and keep the app focused on the MVP workflow
- [ ] T007 Configure the backend CORS policy to allow the frontend origin for local development
- [ ] T008 Configure the frontend API base URL from configuration to match the backend local port
- [ ] T009 Create the `Subscription` model and supporting backend contract classes in `backend/RSSFeedReader.Api/Models/`
- [ ] T010 Create the in-memory subscription service in `backend/RSSFeedReader.Api/Services/`
- [ ] T011 Create the controller endpoint for listing and adding subscriptions in `backend/RSSFeedReader.Api/Controllers/`

**Checkpoint**: Foundation ready - subscription management implementation can begin.

---

## Phase 3: User Story 1 - Add and review subscriptions (Priority: P1) 🎯 MVP

**Goal**: Allow a user to add a feed URL and immediately see it appear in a simple subscription list.

**Independent Test**: The story is complete when a user can enter a URL, submit it, and see the list update without any feed fetching or parsing.

### Implementation for User Story 1

- [ ] T012 [P] [US1] Create the frontend `Subscription` model in `frontend/RSSFeedReader.UI/Models/Subscription.cs`
- [ ] T013 [P] [US1] Create the API client service for adding and fetching subscriptions in `frontend/RSSFeedReader.UI/Services/SubscriptionApiClient.cs`
- [ ] T014 [US1] Add the subscription page UI in `frontend/RSSFeedReader.UI/Pages/Subscriptions.razor` with an input field and submission button
- [ ] T015 [US1] Add the page logic to submit a URL, call the API, and update the in-memory list immediately in the UI
- [ ] T016 [US1] Render the subscription list in the page and ensure new entries appear without losing existing ones
- [ ] T017 [US1] Handle the empty-input and duplicate-entry edge cases in a minimal, user-friendly way without expanding the MVP scope
- [ ] T018 [US1] Verify the frontend and backend run together locally and the add-to-list flow works end-to-end

**Checkpoint**: At this point, the MVP user story is fully functional and testable independently.

---

## Phase 4: Polish & Validation

**Purpose**: Confirm the MVP works before moving beyond this scope.

- [ ] T019 Run the quick validation steps from [quickstart.md](quickstart.md) and confirm the app behaves as expected
- [ ] T020 Review the feature against the MVP scope and ensure no deferred work from Extended-MVP was accidentally introduced
- [ ] T021 [P] Update any minimal documentation needed to describe the subscription-management workflow for local demo use

---

## Dependencies & Execution Order

### Phase Dependencies

- **Setup (Phase 1)**: No dependencies; can start immediately
- **Foundational (Phase 2)**: Depends on setup completion; blocks all user-story work
- **User Story 1 (Phase 3)**: Depends on the foundational phase and delivers the actual MVP
- **Polish (Phase 4)**: Depends on the MVP being fully working

### Within Each User Story

- Models and client interfaces before UI behavior
- Backend API before frontend submission flow
- Page behavior before final validation

### Parallel Opportunities

- The frontend and backend initialization tasks can proceed in parallel after repo structure is created
- The model and API client tasks are independent and can be implemented in parallel
- Once the foundation is ready, the page and service logic can be developed in tandem

---

## Notes

- This task list is intentionally limited to the defined MVP: adding subscriptions and displaying the list.
- Feed fetching, parsing, persistence, and removal are intentionally deferred.
- The validation step is manual by design for this stage because the feature specification does not require automated tests.
