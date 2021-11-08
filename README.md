
# mars-profile

**Test User Story:**

**Feature:** Seller's Add Profile Details
**Priority:** Major
As a Seller 
I want the feature to add my Profile Details
So that
The people seeking for some skills can look into my details.

**Acceptance Criteria**
 - Seller is able to add the Profile Details.
 - Seller is able to see the seller’s details on the Profile page.

The task consists of two versions:
**Task 1:** For the above User story, Follow BDD and write all the possible test cases on the
Specflow Feature file.

**Solution:** Added all possible scenarios for Add Profile User Story.
Please see [ProfileAll.feature](https://github.com/ManaliJain16/mars-profile/blob/mars-onboarding/MarsQA-1/Feature/ProfileAll.feature)

**Task 2:** Identify any 3 complex test cases from feature file and automate them.
Use this Solution File or this URL to complete your tasks.

**Solution:** 
 - Created a new Solution using Mars QA Solution File as a base.
 - Selected a few Scenarios from the Feature File in Task 1 and created a new feature file called [Profile.feature](https://github.com/ManaliJain16/mars-profile/blob/mars-onboarding/MarsQA-1/Feature/Profile.feature).
 - Based on the selected Scenarios generated Step definations [ProfileFeatureSteps.cs](https://github.com/ManaliJain16/mars-profile/blob/mars-onboarding/MarsQA-1/Feature/ProfileFeatureSteps.cs)
 - Created Profile Page [ProfilePage.cs](https://github.com/ManaliJain16/mars-profile/blob/mars-onboarding/MarsQA-1/SpecflowPages/Pages/ProfilePage.cs) to implement code 

**ToDos:**
 - Thread.Sleep from updateName and description before Clear
 - Use Relative path instead of Absolute path
 - Uncomment code related to Extent Reports