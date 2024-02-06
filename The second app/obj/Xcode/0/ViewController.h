// WARNING
// This file has been generated automatically by Rider IDE to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <AppKit/AppKit.h>


@interface ViewController : NSViewController {
	NSTextField *_age;
	NSTextField *_biggestSalary;
	NSTextField *_employeeToDelete;
	NSTextField *_id;
	NSTextField *_label1;
	NSTextField *_name;
	NSTextField *_salary;
	NSTextField *_salarySUM;
	NSTextField *_smallestAge;
	NSTextField *_surname;
}

@property (nonatomic, retain) IBOutlet NSTextField *age;

@property (nonatomic, retain) IBOutlet NSTextField *biggestSalary;

@property (nonatomic, retain) IBOutlet NSTextField *employeeToDelete;

@property (nonatomic, retain) IBOutlet NSTextField *id;

@property (nonatomic, retain) IBOutlet NSTextField *label1;

@property (nonatomic, retain) IBOutlet NSTextField *name;

@property (nonatomic, retain) IBOutlet NSTextField *salary;

@property (nonatomic, retain) IBOutlet NSTextField *salarySUM;

@property (nonatomic, retain) IBOutlet NSTextField *smallestAge;

@property (nonatomic, retain) IBOutlet NSTextField *surname;

- (IBAction)button1:(NSButton *)sender;

- (IBAction)delete:(NSButton *)sender;

- (IBAction)deleteEmployee:(NSButton *)sender;

- (IBAction)insert:(NSButton *)sender;

- (IBAction)sorted:(NSButton *)sender;

@end
